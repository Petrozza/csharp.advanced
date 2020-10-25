
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private readonly List<Rabbit> data; 

        
        public Cage(string name, int capacity)
        {
            Name = name;
            Capaticy = capacity;
            data = new List<Rabbit>();
        }
        public string Name { get; set; }
        public int Capaticy { get; set; }
        public int Count => data.Count;

        public void Add(Rabbit rabbit)
        {
            if (Count < Capaticy) //??
            {
                data.Add(rabbit);
                
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbitToRemove = data.FirstOrDefault(r => r.Name == name);
            if (rabbitToRemove == null)
            {
                return false;
            }
            else
            {
                return data.Remove(rabbitToRemove);
            }
            
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(r => r.Species == species); //??
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit sellingRabbit = data.FirstOrDefault(r => r.Name == name);
            if (sellingRabbit != null)
            {
                sellingRabbit.Available = false;
            }
            return sellingRabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var sellRabbits = data.Where(r => r.Species == species).ToArray();
            foreach (var rabbit in sellRabbits)
            {
                rabbit.Available = false;
            }
            return sellRabbits;
        }

        public string Report()
        {
            StringBuilder bbb = new StringBuilder();
            bbb.AppendLine($"Rabbits available at {Name}:");
            foreach (var rabbit in data.Where(r => r.Available == true))
            {
                bbb.AppendLine(rabbit.ToString());
            }
            return bbb.ToString().Trim();
        }
    }
}
