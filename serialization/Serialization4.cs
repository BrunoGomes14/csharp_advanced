using System;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Text.Json;




namespace serialization4
{



    public record Aluno 
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Chamada { get; set; }

        public string Turma { get; set; }

        public string Curso { get; set; }
    }






    public class Program 
    {

        public static void Run()
        {

            Aluno aluno = new Aluno()
            {
                Id = 1034,
                Nome = "Bruno de Oliveira",
                Chamada = 18,
                Turma = "InfoX",
                Curso = "Informática"
            };






            // Serializer
            using (var file = new StreamWriter("aluno2.json", append: false))
            {
                var json = JsonSerializer.Serialize<Aluno>(aluno);
                file.WriteLine(json);
            }


            // Deserializer
            using (var file = new StreamReader("aluno2.json"))
            {
                Aluno aluno2 = JsonSerializer.Deserialize<Aluno>(file.ReadToEnd());
                Console.WriteLine(aluno2);
            }


        }
    }



}
