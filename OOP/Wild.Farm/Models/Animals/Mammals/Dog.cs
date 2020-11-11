
using System.Collections.Generic;
using Wild.Farm.Models.Foods;

namespace Wild.Farm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double GainValue = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat) }, GainValue);
        }
        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
