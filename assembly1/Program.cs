using System;

namespace assembly1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(new Calculadora().Somar(10, 4));
            Console.WriteLine(new Calculadora().Subtrair(10, 4));
        }
    }

    public class Calculadora
    {
        public int Somar(int a, int b) => a + b;
        internal int Subtrair(int a, int b) => a - b;
    }
}
