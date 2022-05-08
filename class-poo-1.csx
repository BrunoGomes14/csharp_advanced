
// public class Veiculo
// {
//     public string Placa { get; set; }
//     public string Marca { get; set; }
//     public string Modelo { get; set; }
// }

// Veiculo v = new Veiculo();
// v.Placa = "BBB-0000";
// v.Marca = "Hyunday";
// v.Modelo = "HB20";



// public class Carro : Veiculo
// {

// }

// Carro c = new Carro();
// c.Placa = "AAA-0000";
// c.Marca = "Hyunday";
// c.Modelo = "HB20";



// ===================================================


// public enum Carroceria
// {
//     Hatch,
//     Sedan
// }


// public class Veiculo
// {
//     public string Placa  { get; set; }
//     public string Marca  { get; set; }
//     public string Modelo { get; set; }
// }

// public class Carro : Veiculo
// {
//     public bool ArCondicionado   { get; set; }
//     public bool TravasEletricas  { get; set; }
//     public Carroceria Carroceria { get; set; }
// }

// Carro c = new Carro();
// c.Placa = "AAA-0000";
// c.Marca = "Hyunday";
// c.Modelo = "HB20";
// c.ArCondicionado = true;
// c.TravasEletricas = true;
// c.Carroceria = Carroceria.Sedan;


// Veiculo v = new Veiculo();
// v.Placa = "BBB-0000";
// v.Marca = "Hyunday";
// v.Modelo = "HB20";
// //v.ArCondicionado = true;



// ===================================================


// public enum Carroceria
// {
//     Hatch,
//     Sedan
// }

// public class Veiculo
// {
//     public string Placa  { get; set; }
//     public string Marca  { get; set; }
//     public string Modelo { get; set; }

//     public void Ligar()
//     {
//         Console.WriteLine("Veículo ligado");
//     }
// }


// public class Carro : Veiculo
// {
//     public bool ArCondicionado   { get; set; }
//     public bool TravasEletricas  { get; set; }
//     public Carroceria Carroceria { get; set; }

//     public void LigarAr()
//     {
//         Console.WriteLine("Ar ligado");
//     }   
// }


// Carro c = new Carro();
// c.Placa = "AAA-0000";
// c.Marca = "Hyunday";
// c.Modelo = "HB20";
// c.ArCondicionado = true;
// c.TravasEletricas = true;
// c.Carroceria = Carroceria.Sedan;

// c.Ligar();
// c.LigarAr();


// Veiculo v = new Veiculo();
// v.Placa = "BBB-0000";
// v.Marca = "Hyunday";
// v.Modelo = "HB20";
// //v.ArCondicionado = true;

// v.Ligar();
// //v.LigarAr();





// ===================================================




// public enum Carroceria
// {
//     Hatch,
//     Sedan
// }

// public class Veiculo
// {
//     public string Placa  { get; set; }
//     public string Marca  { get; set; }
//     public string Modelo { get; set; }

//     public void Ligar()
//     {
//         this.InjetarCombustivel();
//         Console.WriteLine("Veículo ligado");
//     }

//     private void InjetarCombustivel()
//     {
//         Console.WriteLine("Injetando combustivel");
//     }

//     protected void ChecarParteEletrica()
//     {
//         Console.WriteLine("Parte elétrica ok");
//     }
// }

// public class Carro : Veiculo
// {
//     public bool ArCondicionado   { get; set; }
//     public bool TravasEletricas  { get; set; }
//     public Carroceria Carroceria { get; set; }

//     public Carro(string placa, string marca, string modelo, bool ar, bool travas, Carroceria carroceria)
//     {
//         base.Placa = placa;
//         base.Marca = marca;
//         base.Modelo = modelo;
//         this.ArCondicionado = ar;
//         this.TravasEletricas = travas;
//         this.Carroceria = carroceria;
//     }

//     public void LigarAr()
//     {
//         Console.WriteLine("Ar ligado");
//     }

//     public void TravarPortas()
//     {
//         base.ChecarParteEletrica();
//         Console.WriteLine("Portas travadas");
//     }
// }



// Carro c = new Carro("AAA-0000", "Hyunday", "HB20", true, true, Carroceria.Sedan);
// c.Ligar();
// c.LigarAr();
// c.TravarPortas();
// // c.ChecarParteEletrica();
// // c.InjetarCombustivel();






// ===================================================




public enum Carroceria
{
    Hatch,
    Sedan
}

public class Veiculo
{
    public string Placa  { get; set; }
    public string Marca  { get; set; }
    public string Modelo { get; set; }

    public Veiculo()
    {

    }

    public Veiculo(string placa, string marca, string modelo)
    {
        this.Placa = placa;
        this.Marca = marca;
        this.Modelo = modelo;
    }

    public virtual void Ligar()
    {
        this.InjetarCombustivel();
        Console.WriteLine("Veículo ligado");
    }

    private void InjetarCombustivel()
    {
        Console.WriteLine("Injetando combustivel");
    }

    protected void ChecarParteEletrica()
    {
        Console.WriteLine("Parte elétrica ok");
    }


}








public class Carro : Veiculo
{
    public bool ArCondicionado   { get; set; }
    public bool TravasEletricas  { get; set; }
    public Carroceria Carroceria { get; set; }

    public Carro(string placa, string marca, string modelo, bool ar, bool travas, Carroceria carroceria)
    {
        this.Placa = placa;
        this.Marca = marca;
        this.Modelo = modelo;
        this.ArCondicionado = ar;
        this.TravasEletricas = travas;
        this.Carroceria = carroceria;
    }

    public override void Ligar()
    {
        Console.WriteLine($"{Modelo} pronto para ir");
    }

    public void LigarAr()
    {
        Console.WriteLine("Ar ligado");
    }

    public void TravarPortas()
    {
        base.ChecarParteEletrica();
        Console.WriteLine("Portas travadas");
    }
}



// Veiculo v = new Veiculo("CCC-0000", "Hyunday", "Corsa");
// v.Ligar();


// Carro c = new Carro("AAA-0000", "Hyunday", "HB20", true, true, Carroceria.Sedan);
// c.Ligar();



// ==============================================================================



public void AquecerVeiculo(Veiculo veiculo)
{
    veiculo.Ligar();
}



Carro c = new Carro("AAA-0000", "Hyunday", "HB20", true, true, Carroceria.Sedan);
AquecerVeiculo(c);


Veiculo v2 = new Veiculo("CCC-0000", "Hyunday", "Corsa");
AquecerVeiculo(v2);


Veiculo v3 = new Carro("BBB-0000", "Hyunday", "Fusca", true, true, Carroceria.Sedan);
AquecerVeiculo(v3);








