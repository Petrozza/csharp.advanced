using Riding.Factory;
using Riding.Models;
using System;
using System.Collections.Generic;

namespace Riding.Core
{
    public class Engine
    {
        private ICollection<BaseHero> raidGroup;
        public Engine()
        {
            raidGroup = new List<BaseHero>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            while (counter < n)
            {
                string name = Console.ReadLine();
                string typeHero = Console.ReadLine();

                try
                {
                    BaseHero hero = HeroCreator.CreateHero(typeHero, name);
                    raidGroup.Add(hero);
                    counter++;
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            double bossPower = double.Parse(Console.ReadLine());
            int powerOfAlleroes = 0;
            foreach (var hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
                powerOfAlleroes += hero.Power;
            }
            if (powerOfAlleroes >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
