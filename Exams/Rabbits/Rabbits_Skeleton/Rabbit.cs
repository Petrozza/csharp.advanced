﻿
namespace Rabbits
{
    public class Rabbit
    {
        
        public Rabbit(string name, string species)
        {
            Name = name;
            Species = species;
            Available = true;
        }
        public string Name { get; set; }
        public string Species { get; set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            return $"Rabbit ({Species}): {Name}";
        }

    }
}
