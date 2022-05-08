using System;

namespace assembly2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            assembly1.Calculadora c = new assembly1.Calculadora();
            Console.WriteLine(c.Somar(10, 4));
            //Console.WriteLine(c.Subtrair(10, 4));
        }        
    }
}
