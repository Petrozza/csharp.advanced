using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Calories
{
    public class Dough
    {
        private string flourType;
        private string bakingType;
        private double weight;

        public Dough(string flourType, string bakingType, double weight)
        {
            FlourType = flourType;
            BakingType = bakingType;
            Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            set
            {
                if (!DoughValidator.IsValidFlourType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public string BakingType
        {
            get { return bakingType; }
            set 
            {
                if (!DoughValidator.IsValidBakingType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingType = value; 
            }
        }

        public double Weight
        {
            get { return weight; }
            set 
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range[1..200].");
                }
                weight = value; 
            }
        }

        public double GetTotalCalories()
        {
            return Weight * 2 
                          * DoughValidator.GetBakingTypesModifier(this.BakingType)
                          * DoughValidator.GetFlourModifier(this.flourType);
        }


    }
}
