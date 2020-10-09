using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../input.txt"))
            {
                int counter = 1;
                string line = reader.ReadLine();
                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        counter++;
                        line = reader.ReadLine();
                    }
                }

            }
        }
    }
}
