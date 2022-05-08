
public static int Int(this string s)
{
    return Convert.ToInt32(s);
}


string x = "10";
int y = Convert.ToInt32(x);
int z = int.Parse(x);
int p = x.Int();




int a = 10;
int b = a.Dobro();


public static int Dobro(this int n)
{
    return n * 2;
}


// -----------------------------------

public class Pessoa
{
    public void Andar()
    {

    }
}


public static void Correr(this Pessoa p)
{

}


Pessoa bruno = new Pessoa();
bruno.Correr();
