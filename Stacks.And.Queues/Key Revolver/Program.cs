using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligencePrice = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsData);
            Queue<int> locks = new Queue<int>(locksData);

            int currentBarrelSize = barrelSize;
            int bulletCounter = 0;
            while (locks.Any() && bullets.Any())
            {
                int currentBullet = bullets.Peek();
                int currentLock = locks.Peek();

                if (currentBarrelSize > 0)
                {
                    if (currentBullet <= currentLock)
                    {
                        bullets.Pop();
                        locks.Dequeue();
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        bullets.Pop();
                        Console.WriteLine("Ping!");
                    }
                    currentBarrelSize--;

                    if (currentBarrelSize <= 0 && bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        currentBarrelSize = barrelSize;
                    }

                    bulletCounter++;
                }
                else
                {
                    Console.WriteLine("Reloading!");
                    currentBarrelSize = barrelSize;
                }
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligencePrice - (bulletCounter * bulletPrice)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
