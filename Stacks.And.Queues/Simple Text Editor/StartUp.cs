using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Text_Editor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<string> state = new Stack<string>();

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                if (command == "1")
                {
                    state.Push(text.ToString());
                    text.Append(input[1]);
                }

                else if (command == "2")
                {
                    int index = int.Parse(input[1]);
                    state.Push(text.ToString());
                    text.Remove(text.Length - index, index);
                }

                else if (command == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                }

                else if (command == "4")
                {
                    if (state.Any())
                    {
                        text.Clear();
                        text.Append(state.Pop());
                    }
                }
            }
        }
    }
}
