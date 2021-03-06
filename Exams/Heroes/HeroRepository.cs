﻿

using System.Collections.Generic;
using System.Linq;

namespace Heroes
{
    public class HeroRepository
    {
        List<Hero> data;

        public HeroRepository()
        {
           List<Hero> Data = new List<Hero>();
        }

        //public Hero Data { get; set; }
        public int Count => data.Count;

        public void Add(Hero hero)
        {
            data.Add(hero);
        }

        public void Remove(string name)
        {
            Hero toRemove = data.FirstOrDefault(h => h.Name == name);
            if (toRemove != null)
            {
                data.Remove(toRemove);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero heroHighestStrenth = data.OrderByDescending(h => h.Item.Strength).FirstOrDefault();
            return heroHighestStrenth;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero heroHighestAbility = data.OrderByDescending(h => h.Item.Ability).FirstOrDefault();
            return heroHighestAbility;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero heroHighestIntelligence = data.OrderByDescending(h => h.Item.Ability).FirstOrDefault();
            return heroHighestIntelligence;
        }

        public override string ToString()
        {
            return $"{data}";
        }
    }
}
