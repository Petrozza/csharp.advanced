﻿using System;

namespace Pizza_Calories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string pizzaName = Console.ReadLine().Split()[1];

                string[] input = Console.ReadLine().Split();

                string flourType = input[1];
                string bakingTyype = input[2];
                double weight = double.Parse(input[3]);

                Dough dough = new Dough(flourType, bakingTyype, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingInput = command.Split();

                    string toppingType = toppingInput[1];
                    double toppingWeight = double.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            

           
        }
    }
}
