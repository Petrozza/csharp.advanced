using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new double[n][];

            for (int row = 0; row < jagged.Length; row++)
            {
                int[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                jagged[row] = new double[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    jagged[row][col] = rowData[col];
                }
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                        
                    }
                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] /= 2;
                    }
                }

            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] commandData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                int row = int.Parse(commandData[1]);
                int col = int.Parse(commandData[2]);
                int value = int.Parse(commandData[3]);

                if (row < 0 || row >= jagged.Length || col < 0 || col >= jagged[row].Length)
                {
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        jagged[row][col] += value;
                        break;

                    case "Subtract":
                        jagged[row][col] -= value;
                        break;
                }

            }


            foreach (double[] row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }

         }
    }
}
