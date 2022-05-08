

// ====================================================================================


int[] nums = { 10, 15, 20, 24 };

var r1 = nums.Any(x => x > 15);
var r2 = nums.First(x => x > 15);
var r3 = nums.Where(x => x > 15);
var r4 = nums.Select(x => $"Este é o número {x}");



Console.WriteLine($"\n{nameof(r1)} :> {r1}");
Console.WriteLine($"\n{nameof(r2)} :> {r2}");


Console.WriteLine($"\n{nameof(r3)}");

r3
 .ToList()
 .ForEach(item => Console.WriteLine(item));


Console.WriteLine($"\n{nameof(r4)}");

r4
 .ToList()
 .ForEach(item => Console.WriteLine(item));




// ====================================================================================


public IEnumerable<T> MyWhere<T>(IEnumerable<T> collection, Func<T, bool> filter)
{
    foreach (var item in collection)
    {
        if (filter(item))
            yield return item;
    }
}


int[] nums2 = { 10, 15, 20, 24 };


var x2 = MyWhere(nums2, 
                 x => x > 15);

x2
 .ToList()
 .ForEach(item => Console.WriteLine(item));


// ====================================================================================


public static IEnumerable<T> MyWhereExtension<T>(this IEnumerable<T> collection, Func<T, bool> filter)
{
    foreach (var item in collection)
    {
        if (filter(item))
            yield return item;
    }
}


int[] nums3 = { 10, 15, 20, 24 };


var x3 = nums3.MyWhereExtension(x => x > 15);

x3
 .ToList()
 .ForEach(item => Console.WriteLine(item));


