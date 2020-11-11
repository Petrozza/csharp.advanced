using System;
using System.Collections.Generic;
using System.Text;
using Wild.Farm.Models.Foods;

namespace Wild.Farm.Models.Animals.Mammals.Fellines
{
    public class Tiger : Felline
    {
        private const double GainValue = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }
        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat) }, GainValue);
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
