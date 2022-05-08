using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;


List<Covid> covid = ReadCSV().ToList();

var collectionTest = GetCollection(covid, "queue");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "stack");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "array");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "arraylist");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "list");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "linkedlist");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "hashtable");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "dictionary");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "sorteddictionary");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "sortedlist");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "hashset");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "sortedset");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "hybriddictionary");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");

collectionTest = GetCollection(covid, "concurrentqueue");
Console.WriteLine($"Write\t\t\t {collectionTest.WriteTest(covid)}");
Console.WriteLine($"ReadOne\t\t\t {collectionTest.ReadOneTest(1000000)}");
Console.WriteLine($"ReadMany\t\t {collectionTest.ReadManyTest("Petrolina")}");
Console.WriteLine($"ReadAll\t\t\t {collectionTest.ReadAllTest()}");




IPerformanceOnCollection GetCollection(List<Covid> covid, string collection)
{
    Console.WriteLine("\n\nTesting for:: " + collection);
    switch (collection)
    {
        case "queue": return new QueueTest();
        case "stack": return new StackTest();
        case "array": return new ArrayTest();
        case "arraylist": return new ArrayListTest();
        case "list": return new ListTest();
        case "linkedlist": return new LinkedListTest();
        case "hashtable": return new HashtableTest();
        case "dictionary": return new DictionaryTest();
        case "sortedlist": return new SortedListTest();
        case "sorteddictionary": return new SortedDictionaryTest();
        case "hashset": return new HashSetTest();
        case "sortedset": return new SortedSetTest();
        case "hybriddictionary": return new HybridDictionaryTest();
        case "concurrentqueue": return new ConcurrentQueueTest();
    }
    return null;
}



class QueueTest : IPerformanceOnCollection
{
    Queue<Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();
        
        while (collection.Count > 0)
            collection.Dequeue();

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        return -1;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();
        
        var x = collection.Dequeue();

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new Queue<Covid>();
        foreach (var item in covid)
        {
            collection.Enqueue(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class StackTest : IPerformanceOnCollection
{
    Stack<Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();
        
        while (collection.Count > 0)
            collection.Pop();

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        return -1;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();
        
        var x = collection.Pop();

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new Stack<Covid>();
        foreach (var item in covid)
        {
            collection.Push(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class ArrayTest : IPerformanceOnCollection
{
    Covid[] collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();
        
        for (int i = 0; i < collection.Length; i++)
        {
            var x = collection[i];
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();
        
        var x = collection.Where(x => x.city == city).ToList();

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();
        
        var x = collection.First(x => x.id == id);

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new Covid[covid.Count];

        int i = 0;
        foreach (var item in covid)
        {
            collection[i++] = item;
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class ArrayListTest : IPerformanceOnCollection
{
    ArrayList collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();
        
        for (int i = 0; i < collection.Count; i++)
        {
            var x = collection[i];
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        return -1;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = collection[id];

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new ArrayList();
        foreach (var item in covid)
        {
            collection.Add(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class ListTest : IPerformanceOnCollection
{
    List<Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();
        
        foreach (var item in collection)
        {
            var x = item;
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = collection.Where(x => x.city == city).ToList();

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = collection.First(x => x.id == id);

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new List<Covid>();
        foreach (var item in covid)
        {
            collection.Add(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class LinkedListTest : IPerformanceOnCollection
{
    LinkedList<Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = collection.First;
        for (int i = 0; i < collection.Count; i++)
        {
            x = x.Next;
        }
        
        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        return -1;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = collection.Find(find);

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    Covid find;
    public long WriteTest(List<Covid> covid)
    {
        find = covid[1000000];
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new LinkedList<Covid>();
        foreach (var item in covid)
        {
            collection.AddLast(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class HashtableTest : IPerformanceOnCollection
{
    Hashtable collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        foreach (DictionaryEntry item in collection)
        {
            var x = ((Covid)item.Value);
        }
        
        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        List<Covid> find = new List<Covid>();
        foreach (DictionaryEntry item in collection)
        {
            if (((Covid)item.Value).city == city)
                find.Add((Covid)item.Value);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = (Covid)collection[id];

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new Hashtable();
        foreach (var item in covid)
        {
            collection.Add(item.id, item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class DictionaryTest : IPerformanceOnCollection
{
    Dictionary<int, Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        foreach (KeyValuePair<int, Covid> item in collection)
        {
            var x = item.Value;
        }
        
        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        List<Covid> find = new List<Covid>();
        foreach (KeyValuePair<int, Covid> item in collection)
        {
            if (item.Value.city == city)
                find.Add(item.Value);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = collection[id];

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new Dictionary<int, Covid>();
        foreach (var item in covid)
        {
            collection.Add(item.id, item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class SortedDictionaryTest : IPerformanceOnCollection
{
    SortedDictionary<int, Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        foreach (KeyValuePair<int, Covid> item in collection)
        {
            var x = item.Value;
        }
        
        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        List<Covid> find = new List<Covid>();
        foreach (KeyValuePair<int, Covid> item in collection)
        {
            if (item.Value.city == city)
                find.Add(item.Value);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = collection[id];

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new SortedDictionary<int, Covid>();
        foreach (var item in covid)
        {
            collection.Add(item.id, item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class SortedListTest : IPerformanceOnCollection
{
    SortedList<int, Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        foreach (KeyValuePair<int, Covid> item in collection)
        {
            var x = item.Value;
        }
        
        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        List<Covid> find = new List<Covid>();
        foreach (KeyValuePair<int, Covid> item in collection)
        {
            if (item.Value.city == city)
                find.Add(item.Value);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = collection[id];

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new SortedList<int, Covid>();
        foreach (var item in covid)
        {
            collection.Add(item.id, item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class HashSetTest : IPerformanceOnCollection
{
    HashSet<Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        foreach (var item in collection.OrderBy(x => x.id).ToList())
        {
            var x = item;
        }
        
        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        List<Covid> find = new List<Covid>();
        foreach (var item in collection)
        {
            if (item.city == city)
                find.Add(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        Covid find = new Covid(id, "","","","","","","","","","","","","","","","","","");
        Covid xx;
        var x = collection.TryGetValue(find, out xx);
        Console.WriteLine(x);

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new HashSet<Covid>(new CovidEquality());
        foreach (var item in covid)
        {
            collection.Add(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class SortedSetTest : IPerformanceOnCollection
{
    SortedSet<Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        foreach (var item in collection)
        {
            var x = item;
        }
        
        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        List<Covid> find = new List<Covid>();
        foreach (var item in collection)
        {
            if (item.city == city)
                find.Add(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        Covid find = new Covid(id, "","","","","","","","","","","","","","","","","","");
        Covid xx;
        var x = collection.TryGetValue(find, out xx);
        Console.WriteLine(x);

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new SortedSet<Covid>(new CovidCompare());
        foreach (var item in covid)
        {
            collection.Add(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class HybridDictionaryTest : IPerformanceOnCollection
{
    HybridDictionary collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        foreach (DictionaryEntry item in collection)
        {
            var x = item.Value;
        }
        
        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        List<Covid> find = new List<Covid>();
        foreach (DictionaryEntry item in collection)
        {
            if (((Covid)item.Value).city == city)
                find.Add((Covid)item.Value);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        var x = (Covid)collection[id];

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new HybridDictionary();
        foreach (var item in covid)
        {
            collection.Add(item.id, item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

class ConcurrentQueueTest : IPerformanceOnCollection
{
    ConcurrentQueue<Covid> collection;

    public long ReadAllTest()
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        Covid x;
        while (collection.Count > 0)
            collection.TryDequeue(out x);

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long ReadManyTest(string city)
    {
        return -1;
    }

    public long ReadOneTest(int id)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        Covid x;
        collection.TryDequeue(out x);

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }

    public long WriteTest(List<Covid> covid)
    {
        var cron = System.Diagnostics.Stopwatch.StartNew();

        collection = new ConcurrentQueue<Covid>();
        foreach (var item in covid)
        {
            collection.Enqueue(item);
        }

        cron.Stop();
        return cron.ElapsedMilliseconds;
    }
}

 
interface IPerformanceOnCollection
{
    long WriteTest(List<Covid> covid);
    long ReadOneTest(int id);
    long ReadManyTest(string city);
    long ReadAllTest();
}


IEnumerable<Covid> ReadCSV()
{
    using (StreamReader sr = new StreamReader("caso_full.csv"))
    {
        int id = 1;
        while (!sr.EndOfStream)
        {
            var values = sr.ReadLine().Split(',');
            yield return new Covid(id++, values[0],values[1], values[2], values[3], values[4], values[5], 
                                   values[6], values[7], values[8], values[9], values[10], values[11],
                                   values[12], values[13], values[14], values[15], values[16], values[17]);
        }
    }
}


record Covid(
int id,
string city,
string city_ibge_code,
string date,
string epidemiological_week,
string estimated_population,
string estimated_population_2019,
string is_last,
string is_repeated,
string last_available_confirmed,
string last_available_confirmed_per_100k_inhabitants,
string last_available_date,
string last_available_death_rate,
string last_available_deaths,
string order_for_place,
string place_type,
string state,
string new_confirmed,
string new_deaths
) : IComparable<Covid>
{
    public int CompareTo(Covid other)
    {
        return id.CompareTo(other.id);
    }
}


class CovidEquality : IEqualityComparer<Covid>, IEqualityComparer
{
    public bool Equals(Covid x, Covid y)
    {
        return x.id == y.id;
    }

    public new bool Equals(object x, object y)
    {
        return x.Equals(y);
    }

    public int GetHashCode(Covid obj)
    {
        return obj.id.GetHashCode();
    }

    public int GetHashCode(object obj)
    {
        return obj.GetHashCode();
    }
}



class CovidCompare : IComparer<Covid>
{
    public int Compare(Covid x, Covid y)
    {
        return x.id.CompareTo(y.id);
    }
}
