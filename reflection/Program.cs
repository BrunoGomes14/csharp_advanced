using System;
using System.Reflection;


namespace reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly calculadora = Assembly.Load("Calculadora, Version=0.0.0.0, Culture=neutral, PublicKeyToken=0fa0fb114a95c2f1, processorArchitecture=MSIL");

            Type calc = calculadora.GetType("Calculadora.Calc");

            // dynamic obj = calculadora.CreateInstance("Calculadora.Calc");
            // object x = obj.Somar(10, 4);
            
            object obj = calculadora.CreateInstance("Calculadora.Calc");
            MethodInfo method = calc.GetMethod("Somar");
            object x = method.Invoke(obj, new object[] { 10, 5 });

            Console.WriteLine(x);
        }
    }
}



