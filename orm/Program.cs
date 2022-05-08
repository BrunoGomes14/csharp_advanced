using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace orm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DMK ORM!");

            var constring = "server=my01.winhost.com;user id=devmonk;password=devmonk;database=mysql_17753_devmonk";
            MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(constring);
            MySql.Data.MySqlClient.MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from tb_produto";

            //MySql.Data.MySqlClient.MySqlParameter

            con.Open();
            MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            Listar<Produto>(reader)
                .ForEach(x => Console.WriteLine($"{x.Id}. {x.Nome} - {x.Descricao} - {x.Preco} - {x.QtdEstoque}"));
        
        }





        static List<T> Listar<T>(MySql.Data.MySqlClient.MySqlDataReader reader) where T : new()
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



    [DMTable("tb_produto")]
    public class Produto
    {
        [DMKey("id_produto", Required = true, TypeField = "int")]
        public int Id { get; set; }

        [DMColumn("nm_produto", Required = true, TypeField = "varchar(255)")]
        public string Nome { get; set; }

        [DMColumn("ds_descricao", TypeField = "varchar(800)")]
        public string Descricao { get; set; }

        [DMColumn("ds_categoria", TypeField = "varchar(255)")]
        public string Categoria { get; set; }

        [DMColumn("vl_preco", TypeField = "decimal(15, 2)")]
        public double Preco { get; set; }
        
        [DMColumn("qtd_estoque", TypeField = "int")]
        public int QtdEstoque { get; set; }

        [DMColumn("vl_avaliacao", TypeField = "decimal(15, 2)")]
        public double Avaliacao { get; set; }
    }

        

    public class DMTable : Attribute
    {
        public string TableName { get; set; }

        public DMTable(string tableName)
        {
            this.TableName = tableName;
        }
    }


    public class DMColumn : Attribute
    {
        public string FieldName { get; set; }

        public DMColumn(string field)
        {
            this.FieldName = field;
        }

        public bool         Required  { get; set; }
        public string       TypeField { get; set; }
        //public object       Default   { get; set; }
    }


    public class DMKey : DMColumn
    {
        public DMKey(string field) 
            : base (field) { }

        public bool AutoIncrement { get; set; } = true;
    }



}
