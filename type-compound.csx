
public class Pessoa 
{
    public string Nome { get; set; }
    public double Altura { get; set; }
}

//

public class Familia
{
    public Pessoa Pai { get; set; }
    public Pessoa Mae { get; set; }
    public List<Pessoa> Filhos { get; set; }

    public Familia()
    {
        Pai = new Pessoa();
    }
}


Familia f = new Familia();
f.Pai.Nome = "asdf";


////////////////////////////


// Compare

class Quadrado
{
    public override bool Equals(object obj)
    {
        return ((Quadrado)obj).Lado == this.Lado;
    }

    public override int GetHashCode()
    {
        return this.Lado.GetHashCode();
    }

    public static bool operator ==(Quadrado q1, Quadrado q2) 
    {
        return q1.Equals(q2);
    }

    public static bool operator !=(Quadrado q1, Quadrado q2) 
    {
        return !q1.Equals(q2);
    }

    public static bool operator >(Quadrado q1, Quadrado q2) 
    {
        return q1.Lado > q2.Lado;
    }

    public static bool operator <(Quadrado q1, Quadrado q2) 
    {
        return q1.Lado < q2.Lado;
    }

    public static Quadrado operator +(Quadrado q1, Quadrado q2)
    {
        return new Quadrado() { Lado = q1.Lado + q2.Lado };
    }

    public override string ToString()
    {
        return $"{{ Lado: {Lado} }}";
    }


    public int Lado { get; set; }

}


Quadrado q1 = new Quadrado() { Lado = 10 };
Quadrado q2 = new Quadrado() { Lado = 10 };
Quadrado q3 = new Quadrado() { Lado = 05 };

Console.WriteLine($"q1 Equals q2\t --> {q1.Equals(q2)}");
Console.WriteLine($"q1 == q2\t --> {q1 == q2}");
Console.WriteLine($"q1 > q3\t\t --> {q1 > q3}");
Console.WriteLine($"q1 + q2\t\t --> {(q1 + q2).Lado}");





/////////////////////////////////////////// 





record Aluno
{
    public string Turma { get; set; }
    public string Nome { get; set; }
    public int Chamada { get; set; }
}

//

Aluno a1 = new Aluno() { Turma = "Devmonk", Nome = "Bruno", Chamada = 1 };
Aluno a2 = new Aluno() { Turma = "Devmonk", Nome = "Bruno", Chamada = 1 };

Console.WriteLine($"a1 Equals a2\t --> {a1.Equals(a2)}");
Console.WriteLine($"a1 == a2\t --> {a1 == a2}");
Console.WriteLine($"a1\t\t --> {a1}");
Console.WriteLine($"a2\t\t --> {a2}");


//

Aluno a3 = a2;
a3.Nome = "Bruno O.";

Console.WriteLine($"a1 Equals a2\t --> {a1.Equals(a2)}");
Console.WriteLine($"a1 == a2\t --> {a1 == a2}");
Console.WriteLine($"a1\t\t --> {a1}");
Console.WriteLine($"a2\t\t --> {a2}");
Console.WriteLine($"a3\t\t --> {a3}");


// 




record Aluno2(string Turma, string Nome, int Chamada);

Aluno2 aa = new Aluno2("DevMonk", "Bruno", 2);
Console.WriteLine(aa);

Aluno2 bb = aa with {};
Console.WriteLine(bb);

Aluno2 cc = aa with { Nome = "prof. Bruno" };
Console.WriteLine(cc);


var (t, n, c) = aa;
Console.WriteLine(t + "," + n + "," + c);



/////
///






int? a = null;

bool xx = a.HasValue;
int yy = a.Value;
int? zz = a;



Console.WriteLine(a);


