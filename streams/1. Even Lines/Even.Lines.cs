using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader("../../../text.txt");
            {
                string row = reader.ReadLine();

                int countRows = 0;
               //string newRow = string.Empty;
                
                while (row != null)
                {
                    if (countRows % 2 == 0)
                    {
                        Regex patrix = new Regex("[.,!?-]");
                        row = patrix.Replace(row, "@");
                        var reversedRow = row.Split().ToArray().Reverse();

                        Console.WriteLine(string.Join(" ", reversedRow));
                    }
                    countRows++;
                    row = reader.ReadLine();

                }

            }
        }
    }
}
