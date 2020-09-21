using System;

namespace Symbol_in_Matrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool IsFind = false;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i,j] == symbol)
                    {
                        IsFind = true; 
                        Console.WriteLine($"({i}, {j})");
                        break;
                    }
                }
                if (IsFind)
                {
                    break;
                }
            }
            if (!IsFind)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
