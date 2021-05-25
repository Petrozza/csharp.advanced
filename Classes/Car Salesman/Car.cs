using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Salesman
{
    public class Car
    {
        private string model;
        private string engine;
        private string weight;
        private string color;
        public Car(string model, Engine engine, string weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{Model}:");
            builder.AppendLine($"  {Engine}");
            builder.AppendLine($"  Weight: {Weight}");
            builder.AppendLine($"  Color: {Color}");

            return builder.ToString().TrimEnd();
        }
    }
}
