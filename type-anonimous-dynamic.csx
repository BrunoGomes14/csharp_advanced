
public class Pessoa 
{
    public string Nome { get; set; }
    public int Idade { get; set; }
}


//public void Ola(Pessoa p) 
//public void Ola(object p)
public void Ola(dynamic p) 
{
    Console.WriteLine($"Olá {p.Nome}, tudo bem?");
}


dynamic pessoa = new {
    Nome = "Bruno",
    Idade = 15
};


Ola(pessoa);
