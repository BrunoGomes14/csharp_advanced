#r "nuget: System.Text.Json"
using System.Text.Json;



public static void Log(this object obj)
{
    Console.WriteLine(obj);
}



















// ==========================================================













public class Devmonk
{
    public int Sum(int a, int b)
    {
        return a + b;
    }

    public bool FirstUpper(string s)
    {
        return char.IsUpper(s[0]);
    }

    // public int Triple<T>(T n)
    // {
    //     return n * 3;
    // }

    // public bool IsValidEmail<T>(T n)
    // {
    //     return n.Contains("@");
    // }

    public void Write<T>(T msg) 
    {
        Console.WriteLine(msg);
    }

}





Devmonk dev = new Devmonk();
var x1 = dev.Sum(10, 4);
var x2 = dev.FirstUpper("Oie");
// var x3 = dev.Triple(2);
//var x4 = dev.IsValidEmail<string>("bruno@gmail.com");


dev.Write<int>(10);
dev.Write<string>("10");











// ==========================================================


public class DevWriter<T>
{
    public void Write(T msg)
    {
        Console.WriteLine(msg);
    }
}

DevWriter<string> devw = new DevWriter<string>();
devw.Write("oie");
//devw.Write(10);



















// ==========================================================


public class Utils
{
    public bool Required<T>(T value) 
    {
        if (value == null 
            || value.Equals(default(T)) 
            || (value is string str && str == string.Empty))
            return false;

        return true;
    }

    public R Converts<R,T>(T value, R defaultValue)
    {
        try
        {
            return (R)Convert.ChangeType(value, typeof(R));     
        }
        catch
        {
            return defaultValue;
        }
    }
}



Utils utils = new Utils();
utils.Required(10).Log();           // true
utils.Required(0).Log();            // false
utils.Required("csharp").Log();     // true
utils.Required("").Log();           // false


utils.Converts<int, string>("10", -1).Log();            // 10
utils.Converts<int, string>("1asdf0", -1).Log();        // -1
utils.Converts<string, int>(100, "").Log();             // "100"
utils.Converts<bool, int>(100, false).Log();            // true























// ==========================





public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}

public class CompanyProvider
{
    public string Name { get; set; }
    public double Rating { get; set; }
}




public class ResponseProduct
{
    public int Status { get; set; }
    public string Message { get; set; }
    public List<Product> Data { get; set; }
}

public class ResponseCompanyProvider
{
    public int Status { get; set; }
    public string Message { get; set; }
    public List<CompanyProvider> Data { get; set; }
}



public class Response<T>
{
    public int Status { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}




var p = new Product();
var c = new CompanyProvider();

var r1 = new Response<Product>() { Data = p };
var r2 = new Response<CompanyProvider>() { Data = c };

















// ==============================================


public class MySerializer
{
    public static string Serialize<T>(Response<T> response)
    {
        return JsonSerializer.Serialize(response);
    }
}


Console.WriteLine(MySerializer.Serialize(r2));




















// ==============================================


public interface ICrud<T>
{
    List<T> List();
    void Save(T model);
    void Update(T model);
    void Remove(T model);
}


public abstract class Crud<T> : ICrud<T>
{
    public List<T> List()
    {
        return default(List<T>);
    }

    public void Remove(T model)
    {
        // EF remove
    }

    public void Save(T model)
    {
        // EF save
    }

    public void Update(T model)
    {
        // EF update
    }
}



public class ProdutDatabase : Crud<Product>
{
    public Product GetById(int id)
    {
        return null;
    }

    public List<Product> ListByCategory(string category)
    {
        return null;
    }
   
}

public class CompanyProviderDatabase : Crud<CompanyProvider>
{


}





















