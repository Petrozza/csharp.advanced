using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] materialsInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] magicLevelInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> materials = new Stack<int>(materialsInput);
            Queue<int> magics = new Queue<int>(magicLevelInput);

            Dictionary<string, int> CraftedToys = new Dictionary<string, int>();

            while (materials.Any() && magics.Any())
            {
                int currentMaterial = materials.Peek();
                int currentMagics = magics.Peek();
                int result = currentMaterial * currentMagics;

                if (materials.Peek() == 0)
                {
                    materials.Pop();
                    //continue;
                }
                if (magics.Peek() == 0)
                {
                    magics.Dequeue();
                    //continue;
                }

                if (result == 150 || result == 250 || result == 300 || result == 400)
                {
                    string present = string.Empty;
                    present = IsEqualToTableResult(result);

                    if (!CraftedToys.ContainsKey(present))
                    {
                        CraftedToys.Add(present, 0);
                    }
                    CraftedToys[present]++;

                    materials.Pop();
                    magics.Dequeue();
                }

                else if (result < 0)
                {
                    int currentResult = currentMaterial + currentMagics;

                    materials.Pop();
                    magics.Dequeue();
                    materials.Push(currentResult);
                }

                else if (!ResultIsInTable(result) && result > 0)
                {
                    magics.Dequeue();
                    materials.Pop();
                    materials.Push(currentMaterial + 15);
                }


            }

            if ((CraftedToys.Keys.Contains("Doll") && CraftedToys.Keys.Contains("Wooden train"))
                || (CraftedToys.Keys.Contains("Teddy bear") && CraftedToys.Keys.Contains("Bicycle")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }

            if (magics.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magics)}");
            }

            if (CraftedToys.Any())
            {
                foreach (var toy in CraftedToys.OrderBy(t => t.Key))
                {
                    Console.WriteLine($"{toy.Key}: {toy.Value}");
                }
            }
        }

        private static bool ResultIsInTable(int result)
        {
            return (result == 150 || result == 250 || result == 300 || result == 400);
        }

        private static string IsEqualToTableResult(int result)
        {
            string present = string.Empty;

            if (result == 150)
            {
                present = "Doll";
            }
            else if (result == 250)
            {
                present = "Wooden train";
            }
            else if (result == 300)
            {
                present = "Teddy bear";
            }
            else if (result == 400)
            {
                present = "Bicycle";
            }

            return present;
        }

    }
}