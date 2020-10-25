
using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int srength, int ability, int intelligence)
        {
            Strength = srength;
            Ability = ability;
            Intelligence = intelligence;
        }

        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Item:");
            sb.AppendLine($" * Strength: {Strength}");
            sb.AppendLine($" * Ability: {Ability}");
            sb.AppendLine($" * Intelligence: {Intelligence}");

            return sb.ToString().TrimEnd();
        }
    }
}
