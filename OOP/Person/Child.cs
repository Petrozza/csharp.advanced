using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {

        }

        //public string Name { get; set; }
        public override int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Ne staa");
                }
                base.Age = value;
            }
        }
    }
}
