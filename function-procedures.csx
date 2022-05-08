


// --------------------------------------------------------------

var x1 = Somar(10, 5);
var x2 = Somar(10, 5, 5.5);
var x3 = Somar();
var x4 = Somar(10, 5, 8, 6, 4, 2, 0);

//double r1;
bool x5 = TentarSomar(10, 5.5, out double r1);

double r2;
bool x6 = TentarSomar("oie", true, out r2);

double x7 = 10;
Dobro(ref x7);


Console.WriteLine($"x1 = {x1}");
Console.WriteLine($"x2 = {x2}");
Console.WriteLine($"x3 = {x3}");
Console.WriteLine($"x4 = {x4}");
Console.WriteLine($"x5 = {x5} r1 = {r1}");
Console.WriteLine($"x6 = {x6} r2 = {r2}");
Console.WriteLine($"x7 = {x7}");


// --------------------------------------------------------------


public int Somar(int n1, int n2)
{
    return n1 + n2;
}

public double Somar(double n1, double n2, double n3)
{
    return n1 + n2 + n3;
}

public double Somar(double n1 = 0, double n2 = 0)
{
    return n1 + n2;
}

public double Somar(double n1, double n2, params double[] nums)
{
    return n1 + n2 + nums.Sum();
}


// --------------------------------------------------------------



public bool TentarSomar(dynamic n1, dynamic n2, out double soma)
{
    soma = double.NaN;
    try
    {
        soma = n1 + n2;
        return true;
    } catch
    {
        return false;
    }
}

public void Dobro(ref double n)
{
    n *= 2;
}



////
///



