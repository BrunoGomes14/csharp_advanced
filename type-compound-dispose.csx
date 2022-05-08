
public class Logger : IDisposable
{
    StreamWriter sw;
    public Logger()
    {
        sw = new StreamWriter("app.log", append: true);
    }

    public void Info(string message)
    {
        sw.WriteLine($"{DateTime.Now}\t INFO\t\t{message}");
    }

    public void Error(string message)
    {
        sw.WriteLine($"{DateTime.Now}\t ERROR\t\t{message}");
    }

    public void Dispose()
    {
        sw.Close();
        sw.Dispose();
    }
}



using (var logger = new Logger())
{
    logger.Info("oiee");
    logger.Info("td bem??");
    logger.Error("deu erro jowww");
}


// var logger = new Logger();
// logger.Info("oiee");
// logger.Info("td bem??");
// logger.Error("deu erro jowww");


Console.ReadKey();