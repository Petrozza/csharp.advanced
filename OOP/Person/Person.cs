using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public virtual int Age 
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ne staa");
                }
                this.age = value;
            } 
        }

        public override string ToString()
        {
            StringBuilder bb = new StringBuilder();
            bb.Append(String.Format($"Name: {Name}, Age: {Age}"));
            return bb.ToString();
        }
    }
}
