using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinaryFormatterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Saving...";
            string path = Console.ReadLine();
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            MySave ms = new MySave();
            ms.name = name;
            ms.age = age;

            Save(path, ms);
        }
        static void Save(string path, MySave what)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, what);
            Console.WriteLine("Saved!!!");
            Process.Start(path);
            stream.Close();
        }
        static object Load(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            object toReturn = formatter.Deserialize(stream);
            stream.Close();
            return toReturn;
        }
    }

    [Serializable]
    public class MySave
    {
        public string name;
        public int age;
    }
}
