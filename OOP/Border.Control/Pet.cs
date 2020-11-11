using System;
using System.Collections.Generic;
using System.Text;

namespace Border.Control
{
    public class Pet : INaming, IBirthable
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            Birthdate = birthDate;
        }

        public string Birthdate { get; private set; }

        public string Name { get; private set; }
    }
}
