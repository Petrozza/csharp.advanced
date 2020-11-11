
using System.Collections.Generic;
using Wild.Farm.Models.Foods;

namespace Wild.Farm.Models.Animals.Mammals.Fellines
{
    public class Cat : Felline
    {
        private const double GainValue = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override void Eat(Food food)
        {
            BaseEat(food, new List<string>() { nameof(Vegetable), nameof(Meat) }, GainValue);
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
