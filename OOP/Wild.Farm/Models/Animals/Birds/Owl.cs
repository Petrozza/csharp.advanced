﻿
using System.Collections.Generic;
using Wild.Farm.Models.Foods;

namespace Wild.Farm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double GainValue = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat) }, GainValue);
        }
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
