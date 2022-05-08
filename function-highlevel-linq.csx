

List<int> numeros  = new List<int>() { 1, 3, 5, 7, 3, 5 };
List<int> numeros2 = new List<int>() { 2, 3, 4, 5 };
List<object> values = new List<object>() { 1, 2, 3, "a", "b", "c" };



// Aggregation
int x1 = numeros.Aggregate((result, next) => result * next);
double x2 = numeros.Average();
int x3 = numeros.Count();
int x4 = numeros.Max();
int x5 = numeros.Min();
int x6 = numeros.Sum();


// Conversion	{ AsEnumerable, Cast, OfType, ToArray, ToDictionary, ToList }
IEnumerable<int> x7 = numeros.AsEnumerable();
IEnumerable<string> x8 = values.Cast<string>();
IEnumerable<string> x9 = values.OfType<string>();
int[] x10 = numeros.ToArray();
List<int> x11 = numeros.ToList();
Dictionary<string, int> x12 = numeros.ToDictionary(x => x.ToString());


// Element
int x13 = numeros.ElementAt(0);
int x14 = numeros.ElementAtOrDefault(100);
int x15 = numeros.First(x => x > 5);
int x16 = numeros.FirstOrDefault(x => x > 100);
int x17 = numeros.Last(x => x > 5);
int x18 = numeros.LastOrDefault(x => x > 5);
int x19 = numeros.Single(x => x == 5);
int x20 = numeros.SingleOrDefault(x => x == 5);



// Generation      { DefaultIfEmpty, Empty, Range, Repeat }
IEnumerable<int> x21 = numeros.DefaultIfEmpty();
IEnumerable<int> x22 = Enumerable.Empty<int>();
IEnumerable<int> x23 = Enumerable.Range(10, 10);
IEnumerable<int> x24 = Enumerable.Repeat(10, 10);


// - Grouping	{ GroupBy }
IEnumerable<IGrouping<string, int>> x25 = numeros.GroupBy(x => x % 2 == 0 ? "Par" : "Ímpar");

foreach (IGrouping<string, int> item in x25)
{
    string chave = item.Key;
    List<int> items = item.ToList();
}

// Join		{ GroupJoin, Join }
var x26 = 0;
var x27 = 0;


// Ordering
IEnumerable<int> x28 = numeros.OrderBy(x => x);
IEnumerable<int> x29 = numeros.OrderByDescending(x => x);
IEnumerable<int> x31 = numeros.OrderBy(x => x).ThenBy(x => x);
IEnumerable<int> x32 = numeros.OrderBy(x => x).ThenByDescending(x => x);
numeros.Reverse();


// Partitioning
IEnumerable<int> x33 = numeros.Skip(3);
IEnumerable<int> x35 = numeros.Take(3);
IEnumerable<int> x37 = numeros.Skip(30).Take(30);

IEnumerable<int> x34 = numeros.SkipWhile(x => x < 5);
IEnumerable<int> x36 = numeros.TakeWhile(x => x < 5);


public class Texto
{
    public string Mensagem { get; set; }
}

// Projection
IEnumerable<Texto> x38 = numeros.Select(x => new Texto { Mensagem = "Esse é o número: " + x.ToString() });
IEnumerable<char> x39 = numeros.SelectMany(x => x.ToString());



// Quantifiers	{ All, Any, Contains }
bool x40 = numeros.All(x => x > 5);
bool x41 = numeros.Any(x => x > 5);
bool x42 = numeros.Contains(5);



// Restriction	{ Where }
IEnumerable<int> x43 = numeros.Where(x => x > 5);



// Set		{ Distinct, Except, Intersect, Union }
IEnumerable<int> x44 = numeros.Distinct();
IEnumerable<int> x45 = numeros.Except(numeros2);
IEnumerable<int> x46 = numeros.Intersect(numeros2);
IEnumerable<int> x47 = numeros.Union(numeros2);

