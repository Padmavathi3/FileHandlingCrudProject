using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Filehandling
{
    class CrudOnCSV
    {
        String path = "D:\\BridgeLabz\\CSHARP\\Filehandling\\Filehandling\\data.csv";

        public void CreateFile()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

        public void WriteOnFile()
        {
            Console.WriteLine("Enter the id, name, and age separated by commas:");
            String text = Console.ReadLine();
            using (StreamWriter sr = new StreamWriter(path, append: true))
            {
                sr.WriteLine(text);
            }
        }

        public void ReadFromFile()
        {
            Console.WriteLine("Reading data from file:");
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        public void UpdateFile(int id, string newName, int newAge)
        {
            List<string> lines = new List<string>(File.ReadAllLines(path));
            bool updated = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string[] fields = lines[i].Split(',');
                if (fields.Length >= 3 && fields[0].Trim() == id.ToString())
                {
                    lines[i] = $"{id},{newName},{newAge}";
                    updated = true;
                    break;
                }
            }

            if (updated)
            {
                File.WriteAllLines(path, lines.ToArray());
                Console.WriteLine("Record updated successfully!");
            }
            else
            {
                Console.WriteLine($"Record with id {id} not found.");
            }
        }

        public void DeleteFromFile(int id)
        {
            List<string> lines = new List<string>(File.ReadAllLines(path));
            bool deleted = false;

            for (int i = 0; i < lines.Count; i++)
            {
                string[] fields = lines[i].Split(',');
                if (fields.Length >= 3 && fields[0].Trim() == id.ToString())
                {
                    lines.RemoveAt(i);
                    deleted = true;
                    break;
                }
            }

            if (deleted)
            {
                File.WriteAllLines(path, lines.ToArray());
                Console.WriteLine("Record deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Record with id {id} not found.");
            }
        }
    }
}
