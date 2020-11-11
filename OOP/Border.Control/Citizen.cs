using System;
using System.Collections.Generic;
using System.Text;

namespace Border.Control
{
    public class Citizen : IIdentified, IBirthable, INaming, IBuyer
    {
        public Citizen(string name, int age, string id, string birthDate)
        {
            Name = name;
            Food = 0;
        }
        public string Birthdate { get; private set; }

        public string Id { get; }

        public string Name { get; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
