using System;

namespace Book_Worm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowLine = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowLine[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }
                int playerRowPrev = playerRow;
                int playerColPrev = playerCol;
                matrix[playerRow, playerCol] = '-';

                if (command == "up")
                {
                    playerRow -= 1;
                }

                else if (command == "down")
                {
                    playerRow += 1;
                }

                else if (command == "left")
                {
                    playerCol -= 1;
                }

                else if (command == "right")
                {
                    playerCol += 1;
                }

               

                if (IsValid(n, playerRow, playerCol) && matrix[playerRow, playerCol] != '-')
                {

                    word += matrix[playerRow, playerCol];
                    matrix[playerRow, playerCol] = '-';
                }

                else if (!IsValid(n, playerRow, playerCol))
                {
                    if (word.Length > 0)
                    {
                        word = word.Remove(word.Length - 1);
                        playerRow = playerRowPrev;
                        playerCol = playerColPrev;
                    }
                }

                matrix[playerRow, playerCol] = 'P';

            }

            Console.WriteLine(word);
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
         }

        private static bool IsValid(int n, int playerRow, int playerCol)
        {
            return playerRow >= 0 && playerRow < n && playerCol >= 0 && playerCol < n;
        }
    }
}
