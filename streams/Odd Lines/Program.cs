using System;
using System.Diagnostics.Tracing;
using System.IO;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../input.txt")) 
            {
                int counter = 0;
                string line = reader.ReadLine();

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    while (line != null)
                    {
                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }


        }
    }
}
