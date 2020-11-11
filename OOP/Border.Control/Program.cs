using System;
using System.Collections.Generic;
using System.Linq;

namespace Border.Control
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commandArg = Console.ReadLine().Split();

                if (commandArg.Count() == 4)
                {
                    string nameCitizen = commandArg[0];
                    int ages = int.Parse(commandArg[1]);
                    string idNumber = commandArg[2];
                    string bisthCitizen = commandArg[3];
                    buyers.Add(new Citizen(nameCitizen, ages, idNumber, bisthCitizen));
                }

                else if (commandArg.Count() == 3)
                {
                    string rebelName = commandArg[0];
                    int rebelAge = int.Parse(commandArg[1]);
                    string rebelGroup = commandArg[2];
                    buyers.Add(new Rebel(rebelName, rebelAge, rebelGroup));
                }
            }

            string inputName = Console.ReadLine();
            while (inputName != "End")
            {
                var buyer = buyers.SingleOrDefault(b => b.Name == inputName);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                inputName = Console.ReadLine();
            }
            Console.WriteLine(buyers.Sum(b => b.Food));

        }
    }
}
