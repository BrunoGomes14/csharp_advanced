
using System.Threading;




public void Thread_1()
{
    Thread t = new Thread(() =>
    {
        Thread.Sleep(1000);
        Console.WriteLine("Olá!");
    });

    t.IsBackground = false;

    t.Start();

    Console.WriteLine("Olá_2!");
}

// Thread_1();






public void Thread_2() 
{
    Task.Factory.StartNew(() =>
    {
        Thread.Sleep(1000);
        Console.WriteLine("Olá!");
    });
}

// Thread_2();






public void Thread_3()
{
    ThreadPool.QueueUserWorkItem((state) =>
    {
        Thread.Sleep(1000);
        Console.WriteLine("Olá!");
    });
}

// Thread_3();











public void Thread_4()
{
    for (int i = 0; i < 15; i++)
    {
        new Thread(() => 
        //ThreadPool.QueueUserWorkItem((state) =>
        {
            Thread.Sleep(500);
            Console.WriteLine("Olá! Sou a thread " + Thread.CurrentThread.ManagedThreadId);
        }).Start();
    }
}


// Thread_4();
// Console.Read();
















public void Thread_5()
{
    Thread t = new Thread(() =>
    {
        Thread.Sleep(1000);
        Console.WriteLine("Olá!");
    });

    Console.WriteLine(t.ThreadState);
    t.Start();
    Console.WriteLine(t.ThreadState);
    Thread.Sleep(1500);
    Console.WriteLine(t.ThreadState);
    // t.Start();
}

// Thread_5();











public async Task Thread_6()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource();
    CancellationToken token = tokenSource.Token;

    Task task = Task.Factory.StartNew(() =>
    {
        Thread.Sleep(1000);
        Console.WriteLine("Olá!");

    }, token);


    tokenSource.Cancel();

    try
    {
        await task;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

await Thread_6();







// public async Task Thread_7()
// {
//     CancellationTokenSource tokenSource = new CancellationTokenSource();
//     CancellationToken token = tokenSource.Token;

//     Task task = Task.Factory.StartNew(() =>
//     {
//         // throw new Exception("zuouuu");
//         Thread.Sleep(1000);
//         Console.WriteLine("Olá!");

//     }, token)
//     .ContinueWith(t => 
//     {
//         //Console.WriteLine(t.Exception.Message);
//         Console.WriteLine($"Terminou com {(t.Exception == null ? "sucesso" : "erro")}");
//     }, TaskContinuationOptions.OnlyOnFaulted);

//     tokenSource.Cancel();
//     await task;
// }


//await Thread_7();

