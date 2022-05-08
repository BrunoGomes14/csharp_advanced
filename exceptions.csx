
class SoParException : Exception
{
    public SoParException() : base("Você só pode enviar números pares")
    {
    }
}




public int SomarEDividir(int a, int b, int c)
{
    if (c < 0)
        throw new Exception("Dividir por negativo eu não deixo =d");

    if (c % 2 == 1)
        throw new SoParException();

    checked
    {
        return (a + b) / c;
    }
}


try
{
    int x = SomarEDividir(2000000000, 2000000000, 0);
    Console.WriteLine(x);
} 
catch (SoParException ex)
{
    Console.WriteLine("Primeiro catch");
    Console.WriteLine($"{ex.GetType()}\t\t {ex.Message}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Segundo catch");
    Console.WriteLine($"{ex.GetType()}\t\t {ex.Message}");
}
catch (ArithmeticException ex)
{
    Console.WriteLine("Terceiro catch");
    Console.WriteLine($"{ex.GetType()}\t\t {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine("Último catch");
    Console.WriteLine($"{ex.GetType()}\t\t {ex.Message}");
}
