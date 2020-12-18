using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReflectionDemo
{
    public class Cat 
    {
        
        public Cat(string name, int age)
        {
            Name = name;
            Age = age;
        }
        [Required]
        public string Name { get; set; } = "Toshko";
        public int Age { get; set; }

        public void Eat()
        {
            Console.WriteLine("eating");
        }
    }
}
