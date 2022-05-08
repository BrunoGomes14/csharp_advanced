
//
// Task.WaitAll, Task.WaitAny
// Task.WhenAll, Task.WhenAny
//


Task t1 = Task.Factory.StartNew(() =>
{
    System.Threading.Thread.Sleep(2000);
    Console.WriteLine("Oie, eu sou a Task 1.");
});

Task t2 = Task.Factory.StartNew(() =>
{
    System.Threading.Thread.Sleep(1000);
    Console.WriteLine("Oie, eu sou a Task 2.");
});

Task t3 = Task.Factory.StartNew(() =>
{
    System.Threading.Thread.Sleep(100);
    Console.WriteLine("Oie, eu sou a Task 3.");
});


Task.WaitAll(t1, t2, t3);
Task.WaitAny(t1, t2, t3);

await Task.WhenAll(t1, t2, t3);
await Task.WhenAny(t1, t2, t3);












//
// Exemplo com await e Task.WaitAll, Task.WaitAny
//
//

public Task<List<int>> ConsultarIDs_SQL()
{
    return Task.Factory.StartNew<List<int>>(() =>
    {
        System.Threading.Thread.Sleep(2000);
        return new List<int> { 10, 20, 50 };
    });
}

public Task<List<int>> ConsultarIDs_ORACLE()
{
    return Task.Factory.StartNew<List<int>>(() =>
    {
        System.Threading.Thread.Sleep(4000);
        return new List<int> { 10, 50, 70 };
    });
}






// public async Task<List<int>> UnirIDs_1()
// {
//     List<int> l1 = await ConsultarIDs_SQL();
//     List<int> l2 = await ConsultarIDs_ORACLE();

//     List<int> todos = l1.Union(l2).ToList();
//     return todos;
// }

// List<int> ids = await UnirIDs_1();
// ids.ForEach(x => Console.WriteLine(x));





public List<int> UnirIDs_2()
{
    Task<List<int>> t1 = ConsultarIDs_SQL();
    Task<List<int>> t2 = ConsultarIDs_ORACLE();

    Console.WriteLine(t1.Status);
    Console.WriteLine(t2.Status);

    Task.WaitAll(t1, t2);
    //Task.WaitAny(t1, t2);

    Console.WriteLine(t1.Status);
    Console.WriteLine(t2.Status);

    List<int> todos = t1.Result.Union(t2.Result).ToList();
    return todos;
}


List<int> ids2 = UnirIDs_2();
ids2.ForEach(x => Console.WriteLine(x));

