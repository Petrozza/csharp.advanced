using System;
using System.Linq;

namespace JaggedArray_Modification

{
    class StartUp
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[i] = rowData;
            }


            while (true)
            {
                string inputData = Console.ReadLine();

                if (inputData == "END")
                {
                    break;
                }

                string[] input = inputData.Split();

                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || col > jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (command == "Add")
                {
                    jaggedArray[row][col] += value;
                }

                if (command == "Subtract")
                {
                    jaggedArray[row][col] -= value;
                }
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", item));
            }





        }
    }
}

