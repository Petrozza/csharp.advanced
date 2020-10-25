using System;

namespace Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int firstRow = -1;
            int firstCol = -1;
            int secondRow = -1;
            int secondCol = -1;

            for (int row = 0; row < n; row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (matrix[row, col] == 'f')
                    {
                        firstRow = row;
                        firstCol = col;
                    }
                    if (matrix[row, col] == 's')
                    {
                        secondRow = row;
                        secondCol = col;
                    }
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commandF = input[0];
                string commandS = input[1];
               
                GetPosition(ref firstRow, ref firstCol, commandF);
                GetPosition(ref secondRow, ref secondCol, commandS);

                GetToOtherSide(n, ref firstRow, ref firstCol);
                GetToOtherSide(n, ref secondRow, ref secondCol);

                if (matrix[firstRow, firstCol] == 's')
                {
                    matrix[firstRow, firstCol] = 'x';
                    break;
                }
                else if (matrix[firstRow, firstCol] == '*')
                {
                    matrix[firstRow, firstCol] = 'f';
                }

                if (matrix[secondRow, secondCol] == 'f')
                {
                    matrix[secondRow, secondCol] = 'x';
                    break;
                }
                else if (matrix[secondRow, secondCol] == '*')
                {
                    matrix[secondRow, secondCol] = 's';
                }


                matrix[firstRow, firstCol] = 'f';
                matrix[secondRow, secondCol] = 's';


            }
            Print(matrix);

        }

        private static void GetToOtherSide(int n, ref int firstRow, ref int firstCol)
        {
            if (firstRow > n - 1)
            {
                firstRow = 0;
            }
            if (firstRow < 0)
            {
                firstRow = n - 1;
            }
            if (firstCol < 0)
            {
                firstCol = n - 1;
            }
            if (firstCol > n - 1)
            {
                firstCol = 0;
            }
        }

        private static void GetPosition(ref int firstRow, ref int firstCol, string commandF)
        {
            if (commandF == "up")
            {
                firstRow--;
            }
            else if (commandF == "down")
            {
                firstRow++;
            }
            else if (commandF == "left")
            {
                firstCol--;
            }
            else if (commandF == "right")
            {
                firstCol++;
            }
        }

        private static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
