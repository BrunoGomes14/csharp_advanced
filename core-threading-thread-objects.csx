using System.Threading;




public void Contar()
{
    int contador = 0;

    List<Task> tasks = new List<Task>();
    for (int i = 0; i < 100; i++)
    {
        tasks.Add(
            Task.Run(() =>
            {
                Interlocked.Increment(ref contador);
            }));
    }

    Task.WaitAll(tasks.ToArray());

    Console.WriteLine(contador);
}

// Contar();








public void Sincronizacao_1()
{
    AutoResetEvent autoResetEvent = new AutoResetEvent(false);

    for (int i = 0; i < 5; i++)
    {
        new Task(() => 
        //new Thread(() =>
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} executando..");
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} aguardando liberação..");
            autoResetEvent.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finalizada.");
        }).Start();
    }


    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Pressione <enter> para liberar:");
        Console.ReadLine();
        autoResetEvent.Set();
    }
}

// Sincronizacao_1();








public void Sincronizacao_2()
{
    ManualResetEvent manualResetEvent = new ManualResetEvent(false);

    for (int i = 0; i < 5; i++)
    {
        new Task(() => 
        //new Thread(() =>
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} executando..");
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} aguardando liberação..");
            manualResetEvent.WaitOne();
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finalizada.");
        }).Start();
    }


    Console.WriteLine("Pressione <enter> para liberar:");
    Console.ReadLine();
    manualResetEvent.Set();
}

// Sincronizacao_2();
// Console.Read();









public void Sincronizacao_3()
{
    Random rdn = new Random();
    string value = string.Empty;
    ReaderWriterLock readerWriterLock = new ReaderWriterLock();


    Task[] tasks = new Task[10];
    for (int i = 0; i < 10; i++)
    {
        Task tw = Task.Factory.StartNew(() => 
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} tentando escrever..");
            readerWriterLock.AcquireReaderLock(60*1000);

            value = rdn.Next(1000, 9999).ToString();
            Thread.Sleep(1*1000);

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} escreveu: {value}");
            readerWriterLock.ReleaseReaderLock();
        });

        tasks[i] = tw;
        Thread.Sleep(1);
    }

    Task.WaitAll(tasks);
}


// Sincronizacao_3();













public void Sincronizacao_4()
{
    Random rdn = new Random();
    string value = string.Empty;
    Mutex mutex = new Mutex();


    Task[] tasks = new Task[10];
    for (int i = 0; i < 10; i++)
    {
        Task tw = Task.Factory.StartNew(() => 
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} tentando escrever..");
            mutex.WaitOne();

            value = rdn.Next(1000, 9999).ToString();
            Thread.Sleep(1*1000);

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} escreveu: {value}");
            mutex.ReleaseMutex();
        });

        tasks[i] = tw;
        Thread.Sleep(1);
    }

    Task.WaitAll(tasks);
}


// Sincronizacao_4();













public void Sincronizacao_5()
{
    Random rdn = new Random();
    string value = string.Empty;


    Task[] tasks = new Task[10];
    for (int i = 0; i < 10; i++)
    {
        Task tw = Task.Factory.StartNew(() => 
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} tentando escrever..");
            Monitor.Enter(rdn);

            value = rdn.Next(1000, 9999).ToString();
            Thread.Sleep(1*1000);

            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} escreveu: {value}");
            Monitor.Exit(rdn);
        });

        tasks[i] = tw;
        Thread.Sleep(1);
    }

    Task.WaitAll(tasks);
}


// Sincronizacao_5();

/*

lock(rdn)
{


}

*/















// public void Sincronizacao_6()
// {
//     Random rdn = new Random();
//     string value = string.Empty;


//     Task[] tasks = new Task[10];
//     for (int i = 0; i < 10; i++)
//     {
//         Task tw = Task.Factory.StartNew(() => 
//         {
//             Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} tentando escrever..");
//             Monitor.Enter(rdn);

//             value = rdn.Next(1000, 9999).ToString();
//             Thread.Sleep(1*1000);

//             Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} escreveu: {value}");
//             Monitor.Exit(rdn);
//         });

//         tasks[i] = tw;
//         Thread.Sleep(1);
//     }

//     Task.WaitAll(tasks);
// }


// Sincronizacao_6();


