

public interface ICompra
{
    double Calcular(int parcelas, double valor, double taxa);
}

public class CompraA : ICompra
{
    public double Calcular(int parcelas, double valor, double taxa)
    {
        throw new NotImplementedException();
    }
}



public abstract class Compra
{
    public double ConverterTaxa(double taxa)
    {
        return taxa / 100;
    }
}



public sealed class CompraComJurosSimples : Compra, ICompra
{
    public double Calcular(int parcelas, double valor, double taxa)
    {
        return valor + (valor * parcelas * base.ConverterTaxa(taxa));
    }

}




public sealed class CompraComJurosCompostos : Compra, ICompra
{
    public double Calcular(int parcelas, double valor, double taxa)
    {
        return valor * Math.Pow(1 + base.ConverterTaxa(taxa), parcelas);
    }

    public void DarDesconto()
    {

    }
}






void Calcular(ICompra compra, int parcelas, double valor)
{
    double novoValor = compra.Calcular(parcelas, valor, taxa: 3);
    Console.WriteLine(novoValor);
}



Calcular(new CompraComJurosSimples(), parcelas: 36, valor: 50000);
Calcular(new CompraComJurosCompostos(), parcelas: 36, valor: 50000);
