using System;
using System.Linq;

namespace Present_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPresents = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());


            int santaRow = -1;
            int santaCol = -1;
            int countOfNiceKids = 0;

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] rawInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rawInput[col];
                    if (matrix[row, col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }
                    if (matrix[row, col] == 'V')
                    {
                        countOfNiceKids++;
                    }
                }
            }
           
            
            while (countOfPresents >= 0)
            {
                string command = Console.ReadLine();

                if (command == "Christmas morning")
                {
                    break;
                }

                matrix[santaRow, santaCol] = '-';

                FollowDirection(ref santaRow, ref santaCol, command);

                if (santaRow < 0 || santaRow > size - 1 || santaCol < 0 || santaCol > size - 1)
                {
                    break;
                }

                if (matrix[santaRow, santaCol] == 'V')
                {
                    countOfPresents--;
                    matrix[santaRow, santaCol] = 'S';
                    
                    if (countOfPresents == 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                }

                else if (matrix[santaRow, santaCol] == 'X')
                {
                    matrix[santaRow, santaCol] = '-';
                }

                else if (matrix[santaRow, santaCol] == 'C')
                {
                    matrix[santaRow, santaCol] = 'S';
                    
                    if (matrix[santaRow - 1, santaCol] != '-')
                    {
                        countOfPresents--;
                        matrix[santaRow - 1, santaCol] = '-';
                    }
                    
                    if (matrix[santaRow + 1, santaCol] != '-')
                    {
                        countOfPresents--;
                        matrix[santaRow + 1, santaCol] = '-';
                    }
                    
                    if (matrix[santaRow, santaCol - 1] != '-')
                    {
                        countOfPresents--;
                        matrix[santaRow, santaCol - 1] = '-';
                    }
                    
                    if (matrix[santaRow, santaCol + 1] != '-')
                    {
                        countOfPresents--;
                        matrix[santaRow, santaCol + 1] = '-';
                    }

                    if (countOfPresents >= 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                }
                matrix[santaRow, santaCol] = 'S';
            }

            int countOfLeftNiceKids = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 'V')
                    {
                        countOfLeftNiceKids++;
                    }
                }
            }

            PrintMatrix(size, matrix);

            if (countOfLeftNiceKids == 0)
            {
                Console.WriteLine($"Good job, Santa! {countOfNiceKids} happy nice kid/s.");
            }
            else if (countOfLeftNiceKids >= 0)
            {
                Console.WriteLine($"No presents for {countOfLeftNiceKids} nice kid/s.");
            }

        }


        private static void GoToTheOtherSide(int size, ref int playerRow, ref int playerCol)
        {
            if (playerRow > size - 1)
            {
                playerRow = 0;
            }
            if (playerRow < 0)
            {
                playerRow = size - 1;
            }
            if (playerCol > size - 1)
            {
                playerCol = 0;
            }
            if (playerCol < 0)
            {
                playerCol = size - 1;
            }
        }

        private static void FollowDirection(ref int playerRow, ref int playerCol, string command)
        {
            if (command == "up")
            {
                playerRow--;
            }
            else if (command == "down")
            {
                playerRow++;
            }
            else if (command == "left")
            {
                playerCol--;
            }
            else if (command == "right")
            {
                playerCol++;
            }
        }

        private static void PrintMatrix(int size, char[,] matrix)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

    }
}