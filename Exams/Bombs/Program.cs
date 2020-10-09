using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] effectsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] cassingInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> effects = new Queue<int>(effectsInput);
            Stack<int> cassing = new Stack<int>(cassingInput);

            int daturaBombs = 0;
            int cherryBombs = 0;
            int SmokeBombs = 0;

            while (effects.Any() && cassing.Any())
            {
                int currentEffect = effects.Peek();
                int currentCassing = cassing.Peek();
                int sum = currentCassing + currentEffect;


                if (sum >= 40 && sum < 60)
                {
                    while (sum > 40)
                    {
                        currentCassing -= 5;
                        sum = currentCassing + currentEffect;
                    }
                    daturaBombs++;
                    effects.Dequeue();
                    cassing.Pop();
                }
                
                else if (sum >= 60 && sum < 120)
                {
                    while (sum > 60)
                    {
                        currentCassing -= 5;
                        sum = currentCassing + currentEffect;
                    }
                    cherryBombs++;
                    effects.Dequeue();
                    cassing.Pop();
                }
                
                else if (sum >= 120)
                {
                    while (sum > 120)
                    {
                        currentCassing -= 5;
                        sum = currentCassing + currentEffect;
                    }
                    SmokeBombs++;
                    effects.Dequeue();
                    cassing.Pop();
                }

                if (daturaBombs >= 3 && cherryBombs >= 3 && SmokeBombs >= 3)
                {
                    break;
                }
            }

            if (daturaBombs < 3 || cherryBombs < 3 || SmokeBombs < 3)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            if (effects.Count < 1)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effects)}");
            }

            if (cassing.Count < 1)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", cassing)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {SmokeBombs}");
        }
    }
}
