using System;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace serialization3
{



    [Serializable]
    [XmlRoot("Document")]
    public record Aluno 
    {
        [XmlIgnore]
        public int Id;

        [XmlAttribute]
        public string Nome;

        [XmlElement("Numero")]
        public int Chamada;

        [XmlArrayItem("Nota")]
        public double[] Notas;

        public string Turma;

        public string Curso;
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
                Curso = "Informática",
                Notas = new double[] { 6.5, 8.0, 10.0 }
            };




            XmlSerializer serializer = new XmlSerializer(typeof(Aluno));


            // Serializer
            using (var file = new FileStream("aluno.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                serializer.Serialize(file, aluno);
            }


            // Deserializer
            using (var file = new FileStream("aluno.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                Aluno aluno2 = (Aluno)serializer.Deserialize(file);
                Console.WriteLine(aluno2);
            }


        }
    }



}
