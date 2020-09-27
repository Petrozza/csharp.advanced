using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip = new HashSet<string>();

            while (true)
            {
                string invited = Console.ReadLine();
                if (char.IsDigit(invited[0]))
                {
                    vip.Add(invited);
                }
                else if (char.IsLetter(invited[0]) && invited.Length == 8)
                {
                    regular.Add(invited);
                }
                else if (invited == "PARTY")
                {
                    break;
                }
            }

            while (true)
            {
                string came = Console.ReadLine();

                if (char.IsDigit(came[0]))
                {
                    if (vip.Contains(came))
                    {
                        vip.Remove(came);
                    }
                }
                
                else if (char.IsLetter(came[0]) && came.Length == 8)
                {
                    if (regular.Contains(came))
                    {
                        regular.Remove(came);
                    }
                }
                else if (came == "END")
                {
                    break;
                }
            }
            
            int sumNotComming = regular.Count + vip.Count;
            Console.WriteLine(sumNotComming);
            
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
