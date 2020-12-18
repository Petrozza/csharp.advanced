using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(t => t.GetType() == typeof(Terrorist)).ToList();
            var counterTerrorists = players.Where(t => t.GetType() == typeof(CounterTerrorist)).ToList();

            while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(y => y.IsAlive))
            {
                foreach (var terror in terrorists.Where(x => x.IsAlive))
                {
                    if (!terror.IsAlive)
                    {
                        continue;
                    }
                    foreach (var contra in counterTerrorists.Where(x => x.IsAlive))
                    {
                        if (!contra.IsAlive)
                        {
                            continue;
                        }
                        contra.TakeDamage(terror.Gun.Fire());
                    }
                }
                foreach (var contra in counterTerrorists.Where(y => y.IsAlive))
                {
                    if (!contra.IsAlive)
                    {
                        continue;
                    }
                    foreach (var terror in terrorists.Where(y => y.IsAlive))
                    {
                        if (!terror.IsAlive)
                        {
                            continue;
                        }
                        terror.TakeDamage(contra.Gun.Fire());
                    }
                }
            }
            string result = string.Empty;

            if (terrorists.Any(n => n.IsAlive))
            {
                result = "Terrorist wins!";
            }
            else
            {
                result =  "Counter Terrorist wins!";
            }
            return result;
        }
    }
}
