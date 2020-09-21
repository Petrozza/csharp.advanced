using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] songInput = Console.ReadLine().Split(", ").ToArray();

            Queue<string> songs = new Queue<string>(songInput);

            while (songs.Any())
            {
                string input = Console.ReadLine();
                string[] command = input.Split();

                if (command[0] == "Play")
                {
                    songs.Dequeue();
                }

                else if (command[0] == "Add")
                {
                    string song = input.Substring(4);
                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
