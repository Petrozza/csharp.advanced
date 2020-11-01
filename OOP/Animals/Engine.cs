using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Animals
{
    public class Engine
    {
        private const string END_OF_INPUT_COMMAND = "Beast!";
        private readonly List<Animal> animals;
        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string type;
            while ((type = Console.ReadLine()) != END_OF_INPUT_COMMAND)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();

                Animal animal = GetAnimal(type, command);
                this.animals.Add(animal);
            }
        }

        private static string GetGender(string[] command, string gender)
        {
            if (command.Length >= 3)
            {
                gender = command[2];
            }

            return gender;
        }

        private Animal GetAnimal(string type, string[] command)
        {
            string name = command[0];
            int age = int.Parse(command[1]);

            
            string gender = null;
            gender = GetGender(command, gender);

            

            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
