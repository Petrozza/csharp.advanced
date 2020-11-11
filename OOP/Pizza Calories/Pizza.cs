using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pizza_Calories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            toppings = new List<Topping>();
            Name = name;
            Dough = dough;
        }

        public Dough Dough { get; }

        public string Name
        {
            get 
            { 
                return name; 
            }
            private set 
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }

        public int ToppingsCount => toppings.Count;

        public double TotalCalories 
            => toppings.Sum(x => x.GetTotalCalories()) + this.Dough.GetTotalCalories();

        public void AddTopping(Topping topping)
        {
            if (ToppingsCount == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

    }
}
