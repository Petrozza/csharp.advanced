using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Zoo
{
    public class Animal
    {
        public Animal(string name)
        {
            Name = name; 
        }

        public string Name { get; set; }
    }
}