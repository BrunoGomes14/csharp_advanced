

public class Cliente
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Conta { get; set; }
    public int Banco { get; set; }
}




public class ContaCorrente : IDisposable
{
    public double Saldo { get; set; }       // propriedade de instância
    public Cliente cliente1;                // variável de instância 


    public ContaCorrente(Cliente cliente)   // construtor
    {
        this.cliente = cliente;
        Console.WriteLine("conta corrente construída");
    }

    public ContaCorrente() 
    {
        Console.WriteLine("conta corrente construída");
    }

    public void CarregarSaldo()             // método de instância (função que está vinculada a um objeto)
    {
        this.Saldo = 1000000; 
    }

    public void Dispose(bool peloDestrutor)
    {
        Console.WriteLine("conta corrente disposed pelo destrutor: " + peloDestrutor);
    }

    public void Dispose()
    {
        Dispose(peloDestrutor: false);
    }

    ~ContaCorrente()                        // destrutor (coletado pelo GC)
    {
        Dispose(peloDestrutor: true);
    }






    public static double taxaFinanciamentoFuncionarios = 7.0;       // variável de classe

    public static double TaxaFinanciamento { get; set; }            // propriedade de classe


    static ContaCorrente()                                          // construtor estático
    {
        Console.WriteLine("conta corrente construída estática");
    }


    public static double VerificarSaldo(Cliente cliente)            // método de classe
    {
        // lógica do saldo aqui
        double saldo = 0;
        return saldo;
    }

}




Console.ReadKey();
