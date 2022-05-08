using System;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;




namespace serialization2
{



    [DataContract(Name="Aluno", Namespace="http://www.devmonk.com.br")]
    public record Aluno 
    {
        public int Id { get; set; }

        [DataMember(Name="NomeCompleto", IsRequired=true)]
        public string Nome { get; set; }

        [DataMember]
        public int Chamada { get; set; }

        [DataMember(Order=2)]
        public string Turma { get; set; }

        [DataMember(Order=1)]
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




            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Aluno));


            // Serializer
            using (var file = new FileStream("aluno.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                serializer.WriteObject(file, aluno);
            }


            // Deserializer
            using (var file = new FileStream("aluno.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                Aluno aluno2 = (Aluno)serializer.ReadObject(file);
                Console.WriteLine(aluno2);
            }


        }
    }



}
