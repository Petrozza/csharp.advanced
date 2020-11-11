
using System.Collections.Generic;
using Wild.Farm.Models.Foods;

namespace Wild.Farm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double GainValue = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat), nameof(Seeds), nameof(Vegetable), nameof(Fruit) }, GainValue);
        }
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
