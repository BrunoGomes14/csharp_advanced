using System;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace serialization5
{


    [Serializable]
    public record Aluno : ISerializable
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Chamada { get; set; }

        public string Turma { get; set; }

        public string Curso { get; set; }

        public Aluno()
        {
        }
        
        protected Aluno(SerializationInfo info, StreamingContext context)
        {
            Nome = info.GetString("Nomezin");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Nomezin", Nome);
        }
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



            BinaryFormatter serializer = new BinaryFormatter();



            // Serializer
            using (var file = new FileStream("aluno.data", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                serializer.Serialize(file, aluno);
            }


            // Deserializer
            using (var file = new FileStream("aluno.data", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                Aluno aluno2 = (Aluno)serializer.Deserialize(file);
                Console.WriteLine(aluno2);
            }


        }
    }



}
