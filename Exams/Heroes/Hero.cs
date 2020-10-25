
using System.Net.Security;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            Item = item;
        }
        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public override string ToString()
        {
            StringBuilder ss = new StringBuilder();
            ss.AppendLine($"Hero: {Name} – {Level}lvl");
            ss.AppendLine("Item:");
            ss.AppendLine($" * Strength: {Item.Strength}");
            ss.AppendLine($" * Ability: {Item.Ability}");
            ss.AppendLine($" * Intelligence: {Item.Intelligence}");

            return ss.ToString().TrimEnd();
        }
    }
}
