using System;
using System.Threading;


namespace threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Thread t = new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Olá!");
            });

            t.Start();
        }
    }
}
