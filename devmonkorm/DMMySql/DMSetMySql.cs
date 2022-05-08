using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using devmonkorm.Attributes;
using devmonkorm.Helpers;
using MySql.Data.MySqlClient;

namespace devmonkorm.Common
{
    public sealed class DMSetMySql<T> : DMSet<T> where T : class, new()
    {
        private DbParameter[] Parameters;
        private string Query;
        private string WhereClause;
        private string OrderByClause;

        public DMSetMySql(MySqlConnection database) : base(database)
        {
            Database = database;
        }

        public override int Remove(T entity)
        {
            var table = AttributeHelper.GetDMTable(typeof(T));
            var primaryKey = AttributeHelper.GetDMKey(typeof(T));

            Query = new StringBuilder()
                .AppendFormat(" DELETE FROM {0} ", table.TableName)
                .AppendFormat(" WHERE {0} = {1} ", primaryKey.Item1.FieldName, $"@{primaryKey.Item1.FieldName}")
                .ToString();

            Parameters = new MySqlParameter[1];
            Parameters[0] = new MySqlParameter($"@{primaryKey.Item1.FieldName}", primaryKey.Item2.GetValue(entity));

            return ExecuteCommand();
        }

        public override T Add(T entity)
        {
            var table = AttributeHelper.GetDMTable(typeof(T));
            var columns = AttributeHelper.GetDMColumns(typeof(T));

            List<string> fields = new List<string>();
            List<string> values = new List<string>();

            columns = columns.Where(x => !(x.Item1 is Attributes.DMKey)).ToList();
            
            Parameters = new MySqlParameter[columns.Count()];

            for (int i = 0; i < columns.Count; i++)
            {
                Parameters[i] = new MySqlParameter($"@{columns[i].Item1.FieldName}", columns[i].Item2.GetValue(entity));

                // Query String Builder

                fields.Add($"{columns[i].Item1.FieldName}");
                values.Add($"@{columns[i].Item1.FieldName}");
            }

            Query = new StringBuilder()
                .AppendFormat(" INSERT INTO {0} ", table.TableName)
                .AppendFormat(" ( {0} )", String.Join(',', fields)) //
                .AppendFormat(" VALUES ( {0} )", String.Join(',', values))
                .ToString();
            
            ExecuteCommand();
            return entity;
        }

        public override T Update(T entity)
        {
            bool init = true;
            Dictionary<string, Object> dicParams = new Dictionary<string, object>();
            StringBuilder sbUpdate = new StringBuilder();
            var table = AttributeHelper.GetDMTable(typeof(T));            
            var columns = AttributeHelper.GetDMColumns(typeof(T));
            var primaryKey = AttributeHelper.GetDMKey(typeof(T));

            try
            {
                sbUpdate.Append("UPDATE ");
                sbUpdate.Append(table.TableName);
                sbUpdate.Append(" SET ");
                
                foreach (var column in columns)
                {
                    string fieldName = column.Item1.FieldName;
    
                    if (fieldName == primaryKey.Item1.FieldName)
                        continue;
    
                    if (column.Item2.GetValue(entity) == null && column.Item1.Required)
                        throw new NullReferenceException($"Required column '{fieldName}' needs to be defined.");
    
                    if (!init)
                        sbUpdate.Append(", ");
                    else 
                        init = false;
    
                    sbUpdate.Append($"{fieldName} = @{fieldName}");
                    dicParams.Add($"@{fieldName}", column.Item2.GetValue(entity));
                }
    
                sbUpdate.Append($" WHERE {primaryKey.Item1.FieldName} = @{primaryKey.Item1.FieldName}");
                dicParams.Add($"@{primaryKey.Item1.FieldName}", primaryKey.Item2.GetValue(entity));
    
                // Query que para realizar update
                Query = sbUpdate.ToString();
    
                // Atribuir parâmetros
                Parameters = new MySqlParameter[dicParams.Count];
                
                for (int i = 0; i < dicParams.Count; i++)
                {
                    KeyValuePair<string, Object> valuePair = dicParams.ElementAt(i);
                    Parameters[i] = new MySqlParameter(valuePair.Key, valuePair.Value);
                }

                ExecuteCommand();
            }
            finally
            {
                sbUpdate = null;
                dicParams = null;
                table = null;
                columns = null;
                primaryKey = null;
            }

            return entity;
        }

        public override IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            // Passar no algoritmo de escrita do WHERE
            var translator = new MySQLQueryTranslator(typeof(T));
            var queryFilter = translator.Translate(predicate);

            WhereClause = $" WHERE 1=1 AND {queryFilter.Item1} ";

            Parameters = new MySqlParameter[queryFilter.Item2.Count];

            int i = 0;
            foreach (var item in queryFilter.Item2)
            {
                Parameters[i++] = new MySqlParameter($"{item.FieldName}"
                    , item.Value);
            }

            return this;
        }

        public override IEnumerable<T> OrderBy<TOrderBy>(Expression<Func<T, TOrderBy>> expression)
        {
            if (!(expression is MemberExpression))
            {
                throw new ArgumentException("NAO PODE");
            }
            var translator = new MySQLQueryTranslator(typeof(T));
            var queryFilter = translator.Translate(expression);

            OrderByClause = $" ORDER BY {queryFilter.Item1} ";
            Console.WriteLine(OrderByClause);

            return this;
        }

        public override IEnumerable<T> ToList()
        {
            return ExecuteQuery();
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return ToList().GetEnumerator();
        }

        protected override List<T> ExecuteQuery()
        {
            try
            {
                Query = GetQuery();
                Database.Open();

                using (var command = (MySqlCommand)Database.CreateCommand())
                {
                    command.CommandText = Query;

                    if (Parameters != null && Parameters.Count() > 0)
                        command.Parameters.AddRange(Parameters);

                    PrintCommand();

                    var reader = (MySqlDataReader)command.ExecuteReader();
                    return ToList(reader);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                Database.Close();
                Query = null;
                WhereClause = null;
                OrderByClause = null;
            }
        }

        protected override int ExecuteCommand()
        {
            try
            {
                Database.Open();

                using (var command = (MySqlCommand)Database.CreateCommand())
                {
                    command.CommandText = Query;
                    
                    if (Parameters != null && Parameters.Count() > 0)
                        command.Parameters.AddRange(Parameters);

                    return command.ExecuteNonQuery();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                Database.Close();
            }
        }

        private void PrintCommand()
        {
            string command = Query;

            if (Parameters != null && Parameters.Length > 0)
            {
                for (int i = Parameters.Length - 1; i >= 0; i--)
                {
                    var item = Parameters[i];
                    command = command.Replace(item.ParameterName, "'" + item.Value?.ToString() + "'");
                }
            }

            Console.WriteLine(command);
            System.Console.WriteLine();
            System.Console.WriteLine();
        }

        private string GetQuery()
        {
            var table = AttributeHelper.GetDMTable(typeof(T));

            // Migrar criação da query para uma classe específica
            string query = new StringBuilder()
                .AppendFormat(" SELECT * FROM {0} ", table.TableName)
                .AppendFormat(" {0} ", WhereClause)
                .AppendFormat(" {0} ", OrderByClause)
                .ToString();

            return query;
        }

        private List<T> ToList(MySqlDataReader reader)
        {
            List<T> list = new List<T>();

            while (reader.Read())
            {
                T item = new T();
                list.Add(item);

                Type type = typeof(T);
                type.GetProperties()
                    .Where(x => x.GetCustomAttribute<DMColumn>() != null)
                    .ToList()
                    .ForEach(prop =>
                    {
                        var column = prop.GetCustomAttribute<DMColumn>();

                        object fieldValue = Convert.ChangeType(reader[column.FieldName], prop.PropertyType);
                        prop.SetValue(item, fieldValue);
                    });
            }

            return list;
        }
    }
}
