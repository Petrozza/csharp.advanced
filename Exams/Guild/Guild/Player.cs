using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string @class)
        {
            Name = name;
            Class = @class;
            //Rank = "Trial";
            //Description = "n/a";
        }

        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; } = "Trial";
        public string Description { get; set; } = "n/a";
        public override string ToString()
        {
            StringBuilder bb = new StringBuilder();
            bb.AppendLine($"Player {Name}: {Class}");
            bb.AppendLine($"Rank: {Rank}");
            bb.AppendLine($"Description: {Description}");

            return bb.ToString().TrimEnd();
        }
    }
}
