

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        List<Present> data;
        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            List<Present> data = new List<Present>();
        }
        public List<Present> Data { get; set; } = new List<Present>();
        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;


        public void Add(Present present)
        {
            if (Capacity > Count)
            {
                Data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            bool isExist = Data.Any(x => x.Name == name);
            if (!isExist)
            {
                 Present toRemove = Data.FirstOrDefault(p => p.Name == name);
                 Data.Remove(toRemove);
            }
            return isExist;
        }

        public Present GetHeaviestPresent()
        {
            Present heaviestPresent = Data.OrderByDescending(h => h.Weight).First();
            return heaviestPresent;
        }

        public Present GetPresent(string name)
        {
            Present found = Data.FirstOrDefault(p => p.Name == name);
            return found;
        }

        public string Report()
        {
            StringBuilder bb = new StringBuilder();
            bb.AppendLine($"{Color} bag contains:");
            foreach (var item in Data)
            {
                bb.AppendLine($"{item}");
            }

            return bb.ToString().TrimEnd();
        }
    }
}
