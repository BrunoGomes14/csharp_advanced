
// Esteira

// // System.Threading.Interlocked
// // System.Threading.AutoResetEvent
// // System.Threading.ManualResetEvent
// // System.Threading.Monitor
// // System.Threading.Mutex
// // System.Threading.ReaderWriterLock
// // System.Threading.Semaphore
// // System.Threading.SemaphoreSlim

// // System.Threading.Thread
// // System.Threading.ThreadPool
// // System.Threading.Tasks.Parallel
// // System.Threading.Tasks.Task
// // System.Threading.Tasks.TaskFactory

// // Multithreading com UI


using System.Threading;




public void Multithreading_Paralell_Foreach()
{
    List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    Parallel.ForEach(values, v =>
    {
        Console.WriteLine(v);
    });
}

// Console.WriteLine(nameof(Multithreading_Paralell_Foreach));
// Multithreading_Paralell_Foreach();







public void Multithreading_Paralell_For()
{
    List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    Parallel.For(
        fromInclusive: 0, 
        toExclusive: values.Count, 
        i =>
        {
            Console.WriteLine(values[i]);
        });
}

// Console.WriteLine(nameof(Multithreading_Paralell_For));
//Multithreading_Paralell_For();









public void Multithreading_Task_1()
{
    List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    foreach (int item in values)
    {
        Task.Factory.StartNew(() =>
        {
            Console.WriteLine(item);
        });
    }
}

// Console.WriteLine(nameof(Multithreading_Task_1));
// Multithreading_Task_1();

// Thread.Sleep(1);








public void Multithreading_Task_2()
{
    List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    Task.Factory.StartNew(() =>
    {
        Thread.Sleep(2 * 1000);
        foreach (int item in values)
        {
            Console.WriteLine(item);
        }
    }).Wait();

    Console.WriteLine("Executouuu");
}

// Console.WriteLine(nameof(Multithreading_Task_2));
// Multithreading_Task_2();










public async Task Multithreading_Task_3()
{
    List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    Task task = Task.Factory.StartNew(() =>
    {
        foreach (int item in values)
        {
            Console.WriteLine(item);
        }
    });

    await task;
}

// Console.WriteLine(nameof(Multithreading_Task_3));
// await Multithreading_Task_3();









public Task<List<int>> Multithreading_Task_4()
{
    List<int> values = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    Task<List<int>> task = Task.Factory.StartNew<List<int>>(() =>
    {
        List<int> squares = values.Select(x => x * x).ToList();
        return squares;
    });

    return task;
}

// Console.WriteLine(nameof(Multithreading_Task_4));
// List<int> xx = await Multithreading_Task_4();
// xx.ForEach(x => Console.WriteLine(x));




// int x = Task.WaitAny(new Task[] { Task.Run(() =>
// {
//     Console.WriteLine("começou..");
//     System.Threading.Thread.Sleep(10000);
//     Console.WriteLine("terminou..");
// })}, TimeSpan.FromSeconds(3));


// Console.WriteLine(x);
// Console.Read();




/*
 * 
 * Task.WaitAll
 * Task.WaitAny
 * Task.WhenAll
 * Task.WhenAny
 * Task.Run
 * Task.FromResult
 * 
 */
 