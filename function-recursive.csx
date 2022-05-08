



///
/// fatorial(3) => 3 x 2 x 1 = 6
///
/// 
/// 
/// 








public int Fatorial_Comando_Iterativo(int x)
{
    int f = 1;
    for (int i = x; i > 1; i--) 
    {
        f = f * i;
    }
    return f;
}

//int r = Fatorial_Comando_Iterativo(3);
//WriteLine(r);










public int Fatorial_Recursao_Linear(int x)
{
    if (x == 1)
        return 1;

    return x * Fatorial_Recursao_Linear(x - 1);
}

int r = Fatorial_Recursao_Linear(3);
WriteLine(r);


//
// int x = fat(3)
//           3 * fat(2)
//           3 *   2  *  fat(1)
//           3 *   2  *    1


















private int Fatorial_Recursao_Iterativa_Helper(int f, int i)
{
    if (i == 1)
        return f;
    return Fatorial_Recursao_Iterativa_Helper(f * i, i - 1);
}


public int Fatorial_Recursao_Iterativa(int x)
{
    return Fatorial_Recursao_Iterativa_Helper(1, x);
}


// int r = Fatorial_Recursao_Iterativa(3);
// WriteLine(r);




//
// int x = fat(3)
//
//         helper(1, 3)
//         helper(3, 2)
//         helper(6, 1)
//         6
//
//
//         helper(f*i, i--)
















public int ForHelper(int x, int i, Func<int, int, int> func)
{   
    if (i == 1) return x;
    return ForHelper(func(x, i), i - 1, func);
}

public int For(int i, Func<int, int, int> func)
{
    return ForHelper(1, i, func);
}



int x1 = For(5, (t, i) => t + i);
int xx = For(5, (t, i) => t * i);
// WriteLine(xx);


//
// fat(3) => 3 * 2 * 1 = (6)
// somatorio(3) => 3 + 2 + 1 = (6)

