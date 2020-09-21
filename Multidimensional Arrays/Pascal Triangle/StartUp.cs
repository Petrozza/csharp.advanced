using System;

namespace Pascal_Triangle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int currentWidth = 1;
            long[][] triangle = new long[height][];

            for (int row = 0; row < height; row++)
            {
                triangle[row] = new long[currentWidth];
                triangle[row][0] = 1;
                triangle[row][currentWidth - 1] = 1;

                if (currentWidth > 2)
                {
                    for (int col = 1; col < currentWidth -1; col++)
                    {
                        triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                    }
                }
                currentWidth++;
            }

            foreach (var item in triangle)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
