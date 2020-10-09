using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int rowPlayer = -1;
            int colPlayer = -1;

            for (int row = 0; row < size; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowData[col];
                    if (matrix[row, col] == 'f')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                    }
                }
            }
            string command = string.Empty;
            bool endOfCommands = false;

            for (int row = 0; row < countOfCommands; row++)
            {
                int previousRow = rowPlayer;
                int previousCol = colPlayer;

                if (matrix[rowPlayer, colPlayer] != 'B')
                {
                    matrix[rowPlayer, colPlayer] = '-';
                    command = Console.ReadLine();
                }


                if (command == "up")
                {
                    rowPlayer -= 1;

                    if (rowPlayer < 0)
                    {
                        rowPlayer = size - 1;
                    }
                }
                else if (command == "down")
                {
                    rowPlayer += 1;

                    if (rowPlayer > size - 1)
                    {
                        rowPlayer = 0;
                    }
                }
                else if (command == "left")
                {
                    colPlayer -= 1;

                    if (colPlayer < 0)
                    {
                        colPlayer = size - 1;
                    }
                }
                else if (command == "right")
                {
                    colPlayer += 1;

                    if (colPlayer > size - 1)
                    {
                        colPlayer = 0;
                    }
                }

                if (matrix[rowPlayer, colPlayer] == 'B')
                {
                    countOfCommands++; //URGENT!!!! (test 9)
                    continue;
                }

                if (matrix[rowPlayer, colPlayer] == 'T')
                {
                    rowPlayer = previousRow;
                    colPlayer = previousCol;
                }

                if (matrix[rowPlayer, colPlayer] == 'F')
                {
                    Console.WriteLine("Player won!");
                    matrix[rowPlayer, colPlayer] = 'f';
                    break;
                }

                matrix[rowPlayer, colPlayer] = 'f';

                if (row == countOfCommands - 1)
                {
                    endOfCommands = true;
                }
            }

            if (endOfCommands)
            {
                Console.WriteLine("Player lost!");
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}
