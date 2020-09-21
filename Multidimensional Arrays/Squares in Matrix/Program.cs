using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matr = new char[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                char[] symbols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matr[row, col] = symbols[col];
                }
            }

            int count = 0;

            for (int row = 0; row < matr.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matr.GetLength(1) - 1; col++)
                {
                    char currsymbol = matr[row, col];
                    if (currsymbol == matr[row, col+1] && currsymbol == matr[row+1, col] && currsymbol == matr[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);

        }
    }
}
