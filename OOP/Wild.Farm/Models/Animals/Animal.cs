
using System;
using System.Collections.Generic;
using Wild.Farm.Models.Foods;

namespace Wild.Farm.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }
        public abstract string ProduceSound();
        public abstract void Eat(Food food);
        protected void BaseEat(Food food, List<string> eatableFood, double gainValue)
        {
            string typeFood = food.GetType().Name;
            
            if (!eatableFood.Contains(typeFood))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {typeFood}!");
            }
            Weight += food.Quantity * gainValue;
            FoodEaten += food.Quantity;
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }

    }
}
