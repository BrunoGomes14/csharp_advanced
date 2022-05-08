using System;
using System.IO;

namespace filewatcher
{
    class Program
    {

        static void Main(string[] args)
        {
            System.IO.FileSystemWatcher watcher = 
                new System.IO.FileSystemWatcher(
                    Path.Combine(Environment.CurrentDirectory, "conteudoSecreto"));

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            watcher.Changed += (sender, e) =>
            {
                Console.WriteLine(e.ChangeType);
                Console.WriteLine(e.FullPath);
            };

            watcher.Created += (sender, e) =>
            {
                Console.WriteLine(e.ChangeType);
                Console.WriteLine(e.FullPath);
            };

            watcher.Deleted += (sender, e) =>
            {
                Console.WriteLine(e.ChangeType);
                Console.WriteLine(e.FullPath);
            };

            watcher.Renamed += (sender, e) =>
            {
                Console.WriteLine(e.ChangeType);
                Console.WriteLine(e.FullPath);
            };

            watcher.Error += (sender, e) =>
            {
                Console.WriteLine(e.GetException().ToString());
            };

            Console.WriteLine("Aperte qualquer tecla para encerrar..");
            Console.ReadKey();
        }
    }
}
