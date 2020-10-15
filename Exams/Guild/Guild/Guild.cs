

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            Roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }

        public List<Player> Roster { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return Roster.Count; }
        }

        public void AddPlayer(Player player)
        {
            if (Capacity > Count)
            {
                Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            bool isExists = Roster.Any(p => p.Name == name);

            if (isExists)
            {
                var playerToRemove = Roster.FirstOrDefault(p => p.Name == name);
                Roster.Remove(playerToRemove);
            }

            return isExists;
        }

        public void PromotePlayer(string name)
        {
            var playerToPromote = Roster.FirstOrDefault(p => p.Name == name);

            if (playerToPromote.Rank != "Member")
            {
                playerToPromote.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var playerToDemote = Roster.FirstOrDefault(p => p.Name == name);

            if (playerToDemote.Rank != "Trial")
            {
                playerToDemote.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> kickedPlayers = new List<Player>();
            for (int i = 0; i < Roster.Count; i++)
            {
                if (Roster[i].Class == @class)
                {
                    kickedPlayers.Add(Roster[i]);
                    Roster.Remove(Roster[i]);
                    i--;
                }
            }

            return kickedPlayers.ToArray();
        }

        public string Report()
        {
            StringBuilder bbb = new StringBuilder();
            bbb.AppendLine($"Players in the guild: {Name}");

            foreach (var item in Roster)
            {
                bbb.AppendLine($"{item}");
            }

            return bbb.ToString().TrimEnd();
        }
    }
}
