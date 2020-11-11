using System;
using System.Collections.Generic;
using System.Text;

namespace Border.Control
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Food = 0;
        }
        public string Name { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
