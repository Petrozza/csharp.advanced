using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace _5._Directory.Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo fileData = new DirectoryInfo("../../../");
            FileInfo[] filesData = fileData.GetFiles();

            foreach (var file in filesData)
            {
                if (!files.ContainsKey(file.Extension))
                {
                    files.Add(file.Extension, new Dictionary<string, double>());
                }

                files[file.Extension].Add(file.Name, file.Length / 1000.00);
            }

            StreamWriter writer = new StreamWriter(@$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\report.txt");
            
            using(writer)
            
            {
                foreach (var item in files.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
                {
                    writer.WriteLine($"{item.Key}");

                    foreach (var file in item.Value.OrderByDescending(f => f.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }
        }
    }
}
