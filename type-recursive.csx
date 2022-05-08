using System.Collections;



// ARRAY É PRIMITIVO


int[] array = new int[10];
Type tipo = array.GetType();
bool primitivo = tipo.IsPrimitive;

Console.WriteLine(primitivo);



// IENUMERABLE


// using System.Collections;

public class Corrida : IEnumerable<int>
{
    int[] voltas;
    public Corrida(params int[] voltas)
    {
        this.voltas = voltas;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return voltas.OfType<int>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return voltas.GetEnumerator();
    }
}


Corrida c = new Corrida(10, 15, 20, 5);

foreach (var item in c)
{
    Console.WriteLine(item);
}




// CONCURRENT COLLECTIONS

//using System.Collections.Concurrent;

//ConcurrentQueue<int> fila = new ConcurrentQueue<int>();
Queue<int> fila = new Queue<int>();

for (int i = 0; i < 1000; i++)
{
    fila.Enqueue(i);
}


Parallel.For(0, 1000, i =>
{
    int x = 0;
    //fila.TryDequeue(out x);
    fila.Dequeue();
});

Console.WriteLine(fila.Count);




/////////////////////////////////////////// 



class Semaforo
{
    string[] cores = { "Vermelho", "Amarelo", "Verde" };
    string[] acao  = { "Pare", "Espere", "Avance" };

    public string this[int key]
    {
        get  { return cores[key]; }
    }

    public string this[string key]
    {
        get { return acao[cores.ToList().IndexOf(key)]; }
    }

}


Semaforo s = new Semaforo();
string a = s[0];

Console.WriteLine($"[0]\t\t --> {s[0]}");
Console.WriteLine($"[\"Vermelho\"]\t --> {s["Vermelho"]}");

