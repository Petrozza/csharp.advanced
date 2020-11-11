using System;
using System.Collections.Generic;
using Wild.Farm.Models.Animals;
using Wild.Farm.Models.Foods;

namespace Wild.Farm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalArgs = input.Split();

                Animal animal = AnimalFactory.Create(animalArgs);
                    
                string[] foodArgs = Console.ReadLine().Split();

                Food food = FoodFactory.Create(foodArgs);

                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
