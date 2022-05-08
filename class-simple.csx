


class Soma
{
    public int Calcular(int n1, int n2)
    {
        return n1 + n2;
    }
}

Soma s = new Soma();
int x = s.Calcular(10, 5);



// =======================================================


class SomaComEstado
{
    public int N1 { get; set; }
    public int N2 { get; set; }

    public int Calcular()
    {
        return this.N1 + this.N2;
    }
}


SomaComEstado s2 = new SomaComEstado();
s2.N1 = 10;
s2.N2 = 05;
int x2 = s2.Calcular();



// =======================================================


class SomaComEstado2
{
    public int N1 { get; private set; }
    public int N2 { get; private set; }

    public void ConfigurarConta(int n1, int n2)
    {
        this.N1 = n1;
        this.N2 = n2;
    }

    public int Calcular()
    {
        return this.N1 + this.N2;
    }
}


SomaComEstado2 s3 = new SomaComEstado2();
s3.ConfigurarConta(10, 5);
int x3 = s3.Calcular();



// ========================================================


class SomaImutavel
{
    public int N1 { get; }
    public int N2 { get; }

    public SomaImutavel(int n1, int n2)
    {
        this.N1 = n1;
        this.N2 = n2;
    }

    public int Calcular()
    {
        return this.N1 + this.N2;
    }
}


SomaImutavel s4 = new SomaImutavel(10, 5);
//s4.N1 = 10;
int x4 = s4.Calcular();




// ========================================================



class SomaImutavel2
{
    public int N1 { get; }
    public int N2 { get; }
    public int Resultado { get; private set; }

    public SomaImutavel2(int n1, int n2)
    {
        this.N1 = n1;
        this.N2 = n2;
    }

    public void Calcular()
    {
        this.Resultado = this.N1 + this.N2;
    }
}




SomaImutavel2 s5 = new SomaImutavel2(10, 5);
//s4.N1 = 10;
s5.Calcular();
int x5 = s5.Resultado;
