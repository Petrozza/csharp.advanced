using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar, ICar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public int Battery { get; private set; }

        public string Stop()
        {
            return "Breaaak";
            
        }

        public string Start()
        {
            return "Engine start";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
