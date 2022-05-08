using System;
using System.Runtime.Serialization;
using System.IO;


namespace serialization1
{



    [DataContract(Name="AlunoDocument", Namespace="http://www.devmonk.com.br")]
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




            DataContractSerializer serializer = new DataContractSerializer(typeof(Aluno));


            // Serializer
            using (var file = new FileStream("aluno.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                serializer.WriteObject(file, aluno);
            }


            // Deserializer
            using (var file = new FileStream("aluno.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                Aluno aluno2 = (Aluno)serializer.ReadObject(file);
                Console.WriteLine(aluno2);
            }


        }
    }



}
