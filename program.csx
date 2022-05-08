
public class Pessoa 
{
    public string Nome { get; set; }

    public void Ola()
    {
        Console.WriteLine("Olá " + this.Nome);
        BoasVindas();
    }

    private static void BoasVindas()
    {
        Console.WriteLine("Seja bem vindo!");
    }
    
}


Pessoa p = new Pessoa() { Nome = "Bruno" };
p.Ola();
