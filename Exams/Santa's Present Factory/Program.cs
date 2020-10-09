using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materialsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] magicLevelInput= Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> materials = new Stack<int>(materialsInput);
            Queue<int> magics = new Queue<int>(magicLevelInput);

            while (materials.Any() && magics.Any())
            {
                int currentMaterial = materials.Peek();
                int currentMagics = magics.Peek();
                int sum = currentMaterial + currentMagics;



            }
        }
    }
}
