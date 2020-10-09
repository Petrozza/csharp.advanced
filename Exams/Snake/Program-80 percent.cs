using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] square = new char[n, n];

            int snakeRow = -1;
            int snakeCol = -1;
            int leftFood = 0;

            for (int row = 0; row < n; row++)
            {
                string inputRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    square[row, col] = inputRow[col];
                    if (square[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (square[row, col] == '*')
                    {
                        leftFood++;
                    }
                }
            }

            int foodQuantity = 0;

            string command = Console.ReadLine();
            while (foodQuantity < 10)
            {
                square[snakeRow, snakeCol] = '.';

                if (command == "up")
                {
                    snakeRow -= 1;
                }

                else if (command == "down")
                {
                    snakeRow += 1;
                }

                else if (command == "left")
                {
                    snakeCol -= 1;
                }

                else if (command == "right")
                {
                    snakeCol += 1;
                }

                if (snakeRow < 0 || snakeRow > n-1 || snakeRow < 0 || snakeCol > n-1)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (square[snakeRow, snakeCol] == '*')
                {
                    foodQuantity++;
                    leftFood--;

                    if (foodQuantity >= 10)
                    {
                        square[snakeRow, snakeCol] = 'S';
                        break;
                    }

                    //if (leftFood == 0)
                    //{
                    //    Console.WriteLine("Game over!");
                    //    square[snakeRow, snakeCol] = '.';
                    //    break;
                    //}

                }

                if (square[snakeRow, snakeCol] == 'B')
                {
                    square[snakeRow, snakeCol] = '.';

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (square[i, j] == 'B')
                            {
                                snakeRow = i;
                                snakeCol = j;
                                square[snakeRow, snakeCol] = '.';
                            }
                        }
                    }
                }

                command = Console.ReadLine();
                //square[snakeRow, snakeCol] = 'S';
            }


            if (foodQuantity >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(square[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
