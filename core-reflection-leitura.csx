
using System.Reflection;

public class Pessoa 
{
    public string Nome { get; set; }
    
    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public void Ola()
    {
        Console.WriteLine($"Olá para você {Nome}");
    }
}



Type type = typeof(Pessoa);
LerEstrutura(type);



public void LerEstrutura(Type type)
{
    LerClasse(type);
    LerConstrutores(type);
    LerPropriedades(type);
    LerMetodos(type);
}

public void LerClasse(Type type)
{
    Write("### Classe ###", string.Empty);

    Write(type.FullName,                title: nameof(type.FullName));
    Write(type.AssemblyQualifiedName,   title: nameof(type.AssemblyQualifiedName));
    Write(type.BaseType.FullName,       title: nameof(type.BaseType));
    Write(type.DeclaringType.FullName,  title: nameof(type.DeclaringType));
    

    Write(type.IsAbstract,              title: nameof(type.IsAbstract));
    Write(type.IsClass,                 title: nameof(type.IsClass));
    Write(type.IsPrimitive,             title: nameof(type.IsPrimitive));
}

public void LerConstrutores(Type type)
{
    Write("### Construtores ###", string.Empty);
    foreach (var item in type.GetConstructors())
    {
        Write($">> {item.Name}", string.Empty);
        Write(item.IsPublic,            title: nameof(item.IsPublic));
        Write(item.IsPrivate,           title: nameof(item.IsPrivate));


        Write($">> Parameters", string.Empty);
        foreach (var param in item.GetParameters())
        {
            Write($"{param.Name} ({param.ParameterType.Name})");
        }
    }
}

public void LerPropriedades(Type type)
{
    Write("### Propriedades ###", string.Empty);
    foreach (var item in type.GetProperties())
    {
        Write($"{item.Name} ({item.PropertyType.Name})");
    }
}

public void LerMetodos(Type type)
{
    Write("### Métodos ###", string.Empty);
    foreach (var method in type.GetMethods())
    {
        Write($">> {method.Name}  (return {method.ReturnType.Name})");
        foreach (var param in method.GetParameters())
        {
            Write($"{param.Name} ({param.ParameterType.Name})");
        }
    }
}















public void Write(object message, string title = "")
{
    if (message.ToString().Contains("###"))
        Console.WriteLine("\n\n");

    if (message.ToString().Contains(">>"))
        Console.WriteLine();


    
    if (title != "")
        Console.WriteLine($"{title}: " + message);
    else
        Console.WriteLine($"{message}");

    if (message.ToString().Contains("###"))
        Console.WriteLine();

}
Console.WriteLine("\n\n");
