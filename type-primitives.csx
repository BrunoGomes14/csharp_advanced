





// INFERÊNCIA

var x1 = 10;
var x2 = "Oie";
var x3 = true;
var x4 = 10.5m;



// CAST

long y1 = 10;
int y2 = 10;


float a = 10;
decimal b = 10;
double c = 10;

//float aa = b;   nao
//float aa = c;   nao

//decimal bb = a;   nao
//decimal bb = c;   nao

//double cc = a;
//double ccc = b;




// COERCION

string y3 = "oie" + " tudo bem?";
   int y4 = 10 + 10;
string y5 = "20" + 10;




// POLÊMICA
// 
// String É ou NÃO É primitivo ?



// public string simbolo_mais(string n1, int n2)
// {
//     return n1 + n2;
// }

// public string simbolo_mais(string n1, string n2)
// {
//     return n1 + n2;
// }

// public int simbolo_mais(int n1, int n2)
// {
//     return n1 + n2;
// }






// ARITHMETIC OVERFLOW

checked
{
    int b = 1;
    int a = int.MaxValue + b;

    Console.WriteLine(a);   
}

