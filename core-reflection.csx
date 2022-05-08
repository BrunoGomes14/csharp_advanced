

/*
 *
 * Activator
 *
 * Assembly
 * Type
   *
   * ConstructorInfo
   * FieldInfo
   * MemberInfo
   * MethodBase
   * MethodBody
   * MethodInfo
   * ParameterInfo
   * PropertyInfo
   * TypeInfo
   * Attribute
   * 
   * 
 */




//
// Criar um objeto e uma função que lista todos metadados desse objeto
//
// Ler o Summary
// Fazer um Swagger
// Fazer uma ORM
// 


using System.Reflection;




public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public DateTime Nascimento { get; set; }
    public bool Dev { get; set; }
    
    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public void Ola()
    {
        Console.WriteLine($"Olá para você {Nome}");
    }
}



//
//
Type type1 = typeof(Pessoa);


foreach (var item in type1.GetMethods())
    Console.WriteLine($"{item.Name}");


foreach (var item in type1.GetProperties())
    Console.WriteLine($"{item.Name} ({item.PropertyType.Name})");



// //
// //
// Pessoa p = new Pessoa("Bruno");
// Type type2 = p.GetType();

// //
// //
// Type type3 = Type.GetType("Pessoa");

// //
// //
// Assembly assembly;
// Type type4 = assembly.GetType("Pessoa");




