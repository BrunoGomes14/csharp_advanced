using System;
using System.Runtime.InteropServices;

namespace assembly3
{
    class Program
    {

        [DllImport("program.dll")]
        public static extern int somar(int a, int b);


        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!!!");
                int a = somar(10, 30);
                Console.WriteLine(a);     
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
