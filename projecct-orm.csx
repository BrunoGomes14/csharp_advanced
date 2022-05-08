
using System.Reflection;
using System.Linq.Expressions;
using System.Linq;



public class DMContext 
{

}

public class DBSet<T>
{
    
}



///////// EXCEPTION /////////////////////////

public class DMFrameworkException : Exception
{
    public DMFrameworkException(string message) : base (message)
    {
    }
}


public class DMBadConfigFrameworkException : Exception
{
    public DMBadConfigFrameworkException(string message) : base (message)
    {
    }
}


///////// ATRIBUTES /////////////////////////



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





///////// EXAMPLE /////////////////////////


[DMTable("tb_produto")]
public class Produto
{
    [DMKey("id_produto", Required = true, TypeField = "int")]
    public int Id { get; set; }

    [DMColumn("nm_produto", Required = true, TypeField = "varchar(255)")]
    public string Nome { get; set; }

    [DMColumn("ds_produto", TypeField = "varchar(800)")]
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




///////// CREATE TABLE SCRIPT /////////////////////////


public void DMCreateTableScript(Type type)
{
    ReadTableName(type);
    ReadFields(type);
}


public void ReadTableName(Type type)
{
    var table = type.GetCustomAttribute<DMTable>();
    if (table == null) throw new DMBadConfigFrameworkException("Missing Table name");

    WriteLine($"CREATE Table {table.TableName} (");
}


public void ReadFields(Type type)
{
    foreach (var field in type.GetProperties())
    {
        var columnInfo = field.GetCustomAttribute<DMColumn>();
        if (columnInfo == null)
            continue;

        ReadField(field, columnInfo);
    }
    WriteLine(");");
}


public void ReadField(PropertyInfo field, DMColumn columnInfo)
{
    var pk = columnInfo is DMKey key 
                ? $"primary key {(key.AutoIncrement ? "auto_increment" : "")}"
                : "";

    WriteLine($"\t{columnInfo.FieldName} {columnInfo.TypeField} {pk} {(columnInfo.Required ? "not null" : "null")}");
}



// DMCreateTableScript(typeof(Produto));







///////// INSERT SCRIPT /////////////////////////


public void DMInsertScript(Produto produto)
{
    var type = produto.GetType();
    var tableName = DMGetTableName(type);
    var fieldsNames = DMGetFields(type);
    var fieldsValues = DMGetValues(type, produto);

    var script = $"INSERT INTO {tableName} ({fieldsNames}) VALUES ({fieldsValues})";

    WriteLine(script);
}



public string DMGetTableName(Type type)
{
    var dmTable = type.GetCustomAttribute<DMTable>();
    return dmTable.TableName;
}



public string DMGetFields(Type type)
{
    StringBuilder fieldsNames = new StringBuilder();

    var fields = type.GetProperties();
    for (int i = 0; i < fields.Length; i++)
    {
        var field = fields[i];

        var columnInfo = field.GetCustomAttribute<DMColumn>();
        if (columnInfo == null)
            continue;
        if (columnInfo is DMKey key && key.AutoIncrement)
            continue;


        if (fieldsNames.Length != 0)
            fieldsNames.Append(",");

        fieldsNames.Append(columnInfo.FieldName);
    }
    return fieldsNames.ToString();
}



public string DMGetValues(Type type, object produto)
{
    StringBuilder fieldsNames = new StringBuilder();

    var fields = type.GetProperties();
    for (int i = 0; i < fields.Length; i++)
    {
        var field = fields[i];

        var columnInfo = field.GetCustomAttribute<DMColumn>();
        if (columnInfo == null)
            continue;
        if (columnInfo is DMKey key && key.AutoIncrement)
            continue;


        var fieldValue = field.GetValue(produto);
        if (fieldsNames.Length != 0)
            fieldsNames.Append(",");

        fieldsNames
            .Append("'")
            .Append(fieldValue)
            .Append("'");
    }

    return fieldsNames.ToString();
}




Produto p = new Produto()
{
    Nome = "Notebook XPS Dell i9 64GB RAM, 2TB SSD, RTX 3090",
    Descricao = "Notebook para jogar campo' minado e jogar show do milhão =)",
    Categoria = "Notebook",
    Preco = 30000,
    Avaliacao = 9.9,
    QtdEstoque = 10
};

// DMInsertScript(p);







//////// DELETE SCRIPT //////////////////////////



public void DeleteScriptByPk(Type type, int id)
{
    var tableName = DMGetTableName(type);
    var pkField = DMGetPkField(type);

    var deleteScript = $"DELETE FROM {tableName} WHERE {pkField} = {id};";
    WriteLine(deleteScript);
}



public string DMGetPkField(Type type)
{
    return type.GetProperties()
               .FirstOrDefault(p => p.GetCustomAttribute<DMKey>() != null)
               .GetCustomAttribute<DMKey>().FieldName;
}


// DeleteScriptByPk(typeof(Produto), 10);

































///////// SELECT SCRIPT /////////////////////////


public void SelectScript(Type type)
{
    var tableName = DMGetTableName(type);
    var script = $"SELECT * FROM {tableName};";
    WriteLine(script);
}




public void Where(Expression<Func<Produto, bool>> expression)
{
    // WriteLine(expression is LambdaExpression);
    var lambda = expression as LambdaExpression;
    // WriteLine(lambda);


    // foreach (var item in lambda.Parameters)
    // {
    //     WriteLine(item);
    // }

    WriteLine(lambda.Body.NodeType);

    // MethodCallExpression method = (MethodCallExpression)lambda.Body;
    // WriteLine(method.Method.Name);

    // MemberExpression prop = (MemberExpression)method.Object;
    // WriteLine(prop.Member.Name);


    WriteLine(((BinaryExpression)lambda.Body).Right);



    // ConstantExpression arg = (ConstantExpression)method.Arguments[0];
    // WriteLine(arg.Value);




    // WriteLine("Name:");
    // WriteLine(expression.Name);
    // WriteLine("NodeType:");
    // WriteLine(expression.NodeType);
    // WriteLine("Body:");
    // WriteLine(expression.Body);
    // WriteLine("ReturnType:");
    // WriteLine(expression.ReturnType);

    // WriteLine("Parameters:");
    // expression.Parameters.ToList().ForEach(x => WriteLine(x.Name));
}


double v = 100;
Where(x => x.Nome.StartsWith("bruno") || x.Avaliacao > 10);


//IQueryable<Produto> q;




