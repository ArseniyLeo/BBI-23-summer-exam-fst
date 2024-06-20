using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using static Variant_4.Task3;
#region Выберите библиотеку(и) для сериализации
// using Newtonsoft;
// using System.Text.Json;
// using System.Text.Json.Serialization;
#endregion
namespace Variant_4
{
    public class Task4
    {
        
        public abstract class AbstractSerializer
        {
            public abstract void Serialize(object obj, string path);
            public abstract object Deserialize(string path);
        }

        
        public class UniquesSerializer : AbstractSerializer, ICreator
        {
            private Uniques uniques;

            public UniquesSerializer(Uniques uniques)
            {
                this.uniques = uniques;
            }

            public Uniques Uniques => uniques;

            public override void Serialize(object obj, string path)
            {
                if (obj is Uniques)
                {
                    string json = JsonConvert.SerializeObject(obj);
                    File.WriteAllText(path, json);
                }
            }

            public override object Deserialize(string path)
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<Uniques>(json);
            }

           
            public void CreateFolder(string path, string folderName)
            {
                Directory.CreateDirectory(Path.Combine(path, folderName));
            }

            public void CreateFile(string path, string fileName)
            {
                File.Create(Path.Combine(path, fileName)).Close();
            }

            public void CreateFolders(string path, string[] folderNames)
            {
                foreach (string folderName in folderNames)
                {
                    CreateFolder(path, folderName);
                }
            }

            public void CreateFiles(string path, string[] fileNames)
            {
                foreach (string fileName in fileNames)
                {
                    CreateFile(path, fileName);
                }
            }
        }

       
        public interface ICreator
        {
            void CreateFolder(string path, string folderName);
            void CreateFile(string path, string fileName);
            void CreateFolders(string path, string[] folderNames);
            void CreateFiles(string path, string[] fileNames);
        }

        


        //public static void Main(string[] args)
        //{
            
        //    Uniques uniques = new Uniques("This is a sample text with unique words like cat, dog, and box.");

            
        //    UniquesSerializer serializer = new UniquesSerializer(uniques);

            
        //    serializer.Serialize(uniques, "uniques.json");

           
        //    Uniques deserializedUniques = (Uniques)serializer.Deserialize("uniques.json");

            
        //    Console.WriteLine(deserializedUniques);

            
        //    serializer.CreateFolder("C:\\Temp", "MyFolder");
        //    serializer.CreateFile("C:\\Temp", "MyFile.txt");
        //    serializer.CreateFolders("C:\\Temp", new string[] { "Folder1", "Folder2" });
        //    serializer.CreateFiles("C:\\Temp", new string[] { "File1.txt", "File2.txt" });
        //}

    }
}
