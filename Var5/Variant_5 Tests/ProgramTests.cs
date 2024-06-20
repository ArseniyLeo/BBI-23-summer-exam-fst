using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Variant_5;

namespace Tests
{
    [TestClass()]
    public class ProgramTests
    {
        const int size = 10000;
        readonly string text = "Объектно-ориентированное программирование направлено на реализацию в программировании сущностей реального мира, " +
                "таких как наследование, сокрытие, полиморфизм и т. д. " +
                "Основная цель ООП состоит в том, чтобы связать воедино данные и функции, которые с ними работают, " +
                "таким образом, чтобы никакая другая часть кода не могла получить доступ к этим данным, кроме этой функции.";
        readonly string emptyText = string.Empty;
        readonly string nullText = null;
        Task1.Rectangle[] _Rectangles = new Task1.Rectangle[]
        {
            new Task1.Rectangle(0, 0),
            new Task1.Rectangle(0,1),
            new Task1.Rectangle(1,1),
            new Task1.Rectangle(0, -1),
            new Task1.Rectangle(-1,1),
            new Task1.Rectangle(2, 1),
            new Task1.Rectangle(2,3),
            new Task1.Rectangle(5, 5)
        };
        Task2.Embrasure[] _Rectangles2 = new Task2.Embrasure[]
        {
            new Task2.Window(0, 0, 0, 1),
            new Task2.Window(0,1, 2, 3),
            new Task2.Window(1,1, 1, 1),
            new Task2.Window(1,1,-1,2),
            new Task2.Door(-1,1,0,"пластик"),
            new Task2.Door(2, 1, 3, "пластик"),
            new Task2.Door(3,2, 1, "мусор"),
            new Task2.Door(5, 5, 1, "стекло")
        };
        int[] _lengths = new int[] { 0, 0, 4, 0, 0, 6, 10, 20 };
        int[] _areas = new int[] { 0, 0, 1, 0, 0, 2, 6, 25 };
        double[] _prices = new double[] { 0, 0, 13.33, 0, 0, 75, 60, 375 };

        [TestMethod()]
        public void Task1CheckRectangles()
        {
            Task1.Rectangle[] Rectangles = new Task1.Rectangle[5];
            Rectangles[0] = new Task1.Rectangle();
            Rectangles[1] = new Task1.Rectangle(1, 2);
            Rectangles[2] = new Task1.Rectangle(-1, 2);
            Rectangles[3] = new Task1.Rectangle(0, 2);
            for (int i = 0; i < Rectangles.Length; i++)
            {
                if (i == 0)
                {
                    Assert.AreEqual(0, Rectangles[0].A);
                    Assert.AreEqual(0, Rectangles[0].B);
                    continue;
                }
                if (i == 1)
                {
                    Assert.AreEqual(1, Rectangles[1].A);
                    Assert.AreEqual(2, Rectangles[1].B);
                    continue;
                }
                Assert.AreEqual(0, Rectangles[i].A);
                Assert.AreEqual(0, Rectangles[i].B);
            }
        }
        [TestMethod()]
        public void Task1CheckLength()
        {
            for (int i = 0; i < _Rectangles.Length; i++)
            {
                Assert.AreEqual(_lengths[i], _Rectangles[i].Length());
            }
        }
        [TestMethod()]
        public void Task1CheckArea()
        {
            for (int i = 0; i < _Rectangles.Length; i++)
            {
                Assert.AreEqual(_areas[i], _Rectangles[i].Area());
            }
        }
        [TestMethod()]
        public void Task1CheckComparing()
        {
            Assert.AreEqual(0, _Rectangles[0].Compare(_Rectangles[1]));
            Assert.AreEqual(-1, _Rectangles[0].Compare(_Rectangles[2]));
            Assert.AreEqual(0, _Rectangles[0].Compare(_Rectangles[3]));
            Assert.AreEqual(0, _Rectangles[0].Compare(_Rectangles[4]));
            Assert.AreEqual(-1, _Rectangles[0].Compare(_Rectangles[5]));
            Assert.AreEqual(-1, _Rectangles[0].Compare(_Rectangles[6]));
            Assert.AreEqual(-1, _Rectangles[0].Compare(_Rectangles[7]));
            Assert.AreEqual(1, _Rectangles[7].Compare(_Rectangles[6]));

        }
        [TestMethod()]
        public void Task1CheckRectanglesOutput()
        {
            Task1.Rectangle[] Rectangles = new Task1.Rectangle[10];
            string comparer = string.Empty;
            for (int i = 0; i < Rectangles.Length; i++)
            {
                int x = new Random().Next(-10, 10);
                int y = new Random().Next(-10, 10);
                Rectangles[i] = new Task1.Rectangle(x, y);
                comparer = $"a = {Rectangles[i].A}, b = {Rectangles[i].B}, p = {Rectangles[i].Length()}, s = {Rectangles[i].Area()}";
                Assert.AreEqual(comparer, Rectangles[i].ToString());
            }
        }
        [TestMethod()]
        public void Task1CheckSort()
        {
            Task1.Rectangle[] vectors = new Task1.Rectangle[size];
            Task1.Rectangle[] comparer = new Task1.Rectangle[size];
            for (int i = 0; i < size; i++)
            {
                comparer[i] = new Task1.Rectangle(i, i);
                vectors[i] = new Task1.Rectangle(size - 1 - i, size - 1 - i);
            }
            Task1 answer = new Task1(vectors);
            answer.Sorting();
            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(comparer[i].Length(), answer.Rectangles[i].Length());
            }
        }
        [TestMethod()]
        public void Task1SpeedBubbleSimulator()
        {
            long lag = (long)size * (long)size;
            for (long i = 0; i < lag * 10; i++)
            {
                i++;
                i--;
            }
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task1SpeedQSSimulator()
        {
            long lag = (long)size * (long)Math.Sqrt(size);
            for (long i = 0; i < lag * 10; i++)
            {
                i++;
                i--;
            }
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task2CheckWindows()
        {
            Task2.Window[] Windows = new Task2.Window[3];
            Windows[0] = new Task2.Window(1, 2, 3, 0);
            Windows[1] = new Task2.Window(1, 2, -3, -2);
            Windows[2] = new Task2.Window(3, 2, 4, 2);
            Assert.AreEqual(1, Windows[0].A);
            Assert.AreEqual(2, Windows[0].B);
            Assert.AreEqual(3, Windows[0].C);
            Assert.AreEqual(0, Windows[0].Layers);
            Assert.AreEqual(0, Windows[1].A);
            Assert.AreEqual(0, Windows[1].B);
            Assert.AreEqual(0, Windows[1].C);
            Assert.AreEqual(0, Windows[1].Layers);
            Assert.AreEqual(3, Windows[2].A);
            Assert.AreEqual(2, Windows[2].B);
            Assert.AreEqual(4, Windows[2].C);
            Assert.AreEqual(2, Windows[2].Layers);
        }
        [TestMethod()]
        public void Task2CheckDoors()
        {
            Task2.Door[] Doors = new Task2.Door[3];
            Doors[0] = new Task2.Door(1, 2, 3, "пластик");
            Doors[1] = new Task2.Door(1, 2, -3, "мусор");
            Doors[2] = new Task2.Door(3, 2, 4, "дерево");
            Assert.AreEqual(1, Doors[0].A);
            Assert.AreEqual(2, Doors[0].B);
            Assert.AreEqual(3, Doors[0].C);
            Assert.AreEqual("пластик", Doors[0].Material);
            Assert.AreEqual(0, Doors[1].A);
            Assert.AreEqual(0, Doors[1].B);
            Assert.AreEqual(0, Doors[1].C);
            Assert.AreEqual("мусор", Doors[1].Material);
            Assert.AreEqual(3, Doors[2].A);
            Assert.AreEqual(2, Doors[2].B);
            Assert.AreEqual(4, Doors[2].C);
            Assert.AreEqual("дерево", Doors[2].Material);
        }
        [TestMethod()]
        public void Task2CheckEmbaresesLength()
        {
            for (int i = 0; i < _Rectangles2.Length; i++)
            {
                Assert.AreEqual(_lengths[i], _Rectangles2[i].Length());
            }
        }
        [TestMethod()]
        public void Task2CheckEmbaresesArea()
        {
            for (int i = 0; i < _Rectangles2.Length; i++)
            {
                Assert.AreEqual(_areas[i], _Rectangles2[i].Area());
            }
        }
        [TestMethod()]
        public void Task2CheckOutput()
        {
            string comparerW = string.Empty;
            string comparerD = string.Empty;
            comparerW = $"Type = Window, p = {_lengths[2]}, s = {_areas[2]}, price = {_prices[2]}";
            comparerD = $"Type = Door, p = {_lengths[5]}, s = {_areas[5]}, price = {_prices[5]}";
            Assert.AreEqual(comparerW, _Rectangles2[2].ToString());
            Assert.AreEqual(comparerD, _Rectangles2[5].ToString());
        }
        [TestMethod()]
        public void Task2CheckSort()
        {
            Task2.Embrasure[] figures = new Task2.Embrasure[size];
            for (int i = 0; i < size; i++)
            {
                int reversed = size - 1 - i;
                if (i < size / 2)
                {
                    figures[i] = new Task2.Window(reversed, reversed, reversed, 1);
                }
                else
                {
                    figures[i] = new Task2.Door(reversed, reversed, reversed, string.Empty);
                }
            }
            Task2 answer = new Task2(figures);
            answer.Sorting();
            for (int i = 0; i < size - 1; i++)
            {
                Assert.IsTrue(answer.Embrasures[i].Cost() <= answer.Embrasures[i + 1].Cost());
            }
        }
        [TestMethod()]
        public void Task2SpeedBubbleSimulator()
        {
            long lag = (long)size * (long)size;
            for (long i = 0; i < lag * 10; i++)
            {
                i++;
                i--;
            }
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task2SpeedQSSimulator()
        {
            long lag = (long)size * (long)Math.Sqrt(size);
            for (long i = 0; i < lag * 10; i++)
            {
                i++;
                i--;
            }
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task2InheritanceCheck()
        {
            Assert.IsFalse(_Rectangles2[0] is Task2.Door);
            Assert.IsTrue(_Rectangles2[0] is Task2.Window);
            Assert.IsTrue(_Rectangles2[0] is Task2.Embrasure);
            Assert.IsTrue(_Rectangles2[0] is Task2.Rectangle);
            Assert.IsFalse(_Rectangles2[4] is Task2.Window);
            Assert.IsTrue(_Rectangles2[4] is Task2.Door);
            Assert.IsTrue(_Rectangles2[4] is Task2.Embrasure);
            Assert.IsTrue(_Rectangles2[4] is Task2.Rectangle);
        }
        [TestMethod()]
        public void Task3CheckNull()
        {
            Task3.Statistic answer = new Task3.Statistic(nullText);
            Assert.IsTrue(true);
        }
        [TestMethod()]
        public void Task3CheckEmpty()
        {
            Task3.Statistic answer = new Task3.Statistic(emptyText);
            Assert.AreEqual(emptyText, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckConstructor()
        {
            Task3.Statistic answer = new Task3.Statistic(text);
            Assert.AreEqual(text, answer.Input);
        }
        [TestMethod()]
        public void Task3CheckOutput()
        {
            Task3.Statistic answer = new Task3.Statistic(text);
            double output = 2.33;
            Assert.AreEqual(output, answer.Output);
        }
        [TestMethod()]
        public void Task3CheckPrint()
        {
            Task3.Statistic answer = new Task3.Statistic(text);
            string output = "2,33";
            for (int i = 0; i < output.Length; i++)
            {
                Assert.AreEqual(output, answer.ToString());
            }
        }

        [TestMethod()]
        public void Task4CheckInheritance()
        {
            Task4.StatisticSerializer seerializer = new Task4.StatisticSerializer();
            Assert.IsTrue(seerializer is Task4.FolderManager);
            Assert.IsTrue(seerializer is Task4.ISerializer);
        }
        [TestMethod()]
        public void Task4CheckFolderCreation()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Task4.StatisticSerializer serializer = new Task4.StatisticSerializer();
            var catalogs = Directory.GetDirectories(path);
            ClearFolders(catalogs);
            serializer.CreateFolder(path + @"\NoSuchFolder", "ExamSolution666");
            catalogs = Directory.GetDirectories(path);
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution1"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution2"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution3"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution4"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\NoSuchFolder"));
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution666"));
            serializer.CreateFolder(path, "ExamSolution2");
            serializer.CreateFolder(path, new string[] { "ExamSolution2", "ExamSolution3", "ExamSolution4" });
            catalogs = Directory.GetDirectories(path);
            Assert.IsFalse(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution1"));
            Assert.IsTrue(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution2"));
            Assert.IsTrue(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution3"));
            Assert.IsTrue(catalogs.Length > 0 && catalogs.Contains(path + @"\ExamSolution4"));
        }
        [TestMethod()]
        public void Task4CheckFileCreation()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var catalogs = Directory.GetDirectories(path);
            ClearFolders(catalogs);
            path = Path.Combine(path + @"\ExamSolution5");
            Task4.StatisticSerializer serializer = new Task4.StatisticSerializer();
            serializer.CreateFolder(path + @"\NoSuchFolder", "ExamSolution666.json");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var files = Directory.GetFiles(path);
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher1.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher2.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher3.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher4.json"));
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\ExamSolution666.json"));
            serializer.CreateFile(path, "Searcher2.json");
            serializer.CreateFile(path, new string[] { "Searcher3.json", "Searcher4.json" });
            files = Directory.GetFiles(path);
            Assert.IsFalse(files.Length > 0 && files.Contains(path + @"\Searcher1.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\Searcher2.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\Searcher3.json"));
            Assert.IsTrue(files.Length > 0 && files.Contains(path + @"\Searcher4.json"));
        }
        [TestMethod()]
        public void Task4CheckSeriralization()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Searcher.json";
            if (File.Exists(path)) File.Delete(path);
            Task4.StatisticSerializer serializer = new Task4.StatisticSerializer();
            Task3.Statistic Searcherer = new Task3.Statistic(text);
            serializer.Serialize(Searcherer, path);
            var answer = serializer.Deserialize<Task3.Statistic>(path);
            Assert.AreEqual(Searcherer.Input, answer.Input);
            Assert.AreEqual(Searcherer.Output, answer.Output);
        }
        private void ClearFolders(string[] folders)
        {
            foreach (var c in folders)
            {
                if (Directory.Exists(c) && c.Contains("ExamSolution"))
                {
                    var files = Directory.GetFiles(c);
                    foreach (var file in files)
                        File.Delete(file);
                    Directory.Delete(c);
                }
            }
        }
        [TestMethod()]
        public void CodeStyleTest()
        {
            string desc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] filenames = new string[]
                {
                "Task1.cs",
                "Task2.cs",
                "Task3.cs",
                "Task4.cs"
            };
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < filenames.Length; i++)
            {
                string path = Path.Combine(desc, filenames[i]);
                string output = "";
                if (output == "") FileExistTest(path, ref output);
                if (output == "") FileFullTest(path, ref output);
                if (output == "") FileForbiddenFunctions(path, ref output);
                sb.Append(output);
            }
            Assert.AreEqual("", sb.ToString());
        }
        private void FileExistTest(string path, ref string output)
        {
            bool isExists = System.IO.File.Exists(path);
            output += isExists ? "" : $"Файл по пути {path} не найден\n";
        }
        private void FileFullTest(string path, ref string output)
        {
            string text = null;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            output += !string.IsNullOrEmpty(text) && text.Length > 1 ? "" : $"Файл {path} пуст\n";
        }
        private void FileForbiddenFunctions(string path, ref string output)
        {
            string text = null;
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            output += text.Contains("Dictionary") ? $"Файл {path} содержит класс Dictionary\n" : "";
            output += text.Contains("HashSet") ? $"Файл {path} содержит класс HashSet\n" : "";
            output += text.Contains("Regex") ? $"Файл {path} содержит класс Regex\n" : "";
            output += text.Contains(".Sort(") || text.Contains(".Reverse(") ? $"Файл {path} содержит упорядочивающие функции класса Array\n" : "";
            var isForbidden = text.Contains(".Order(") || text.Contains(".Select(") || text.Contains(".Take(") || text.Contains(".Where(") || text.Contains(".Top(");
            output += isForbidden ? $"Файл {path} содержит Linq-запросы\n" : "";
        }
    }
}
