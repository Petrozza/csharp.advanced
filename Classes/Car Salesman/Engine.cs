using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Salesman
{
    public class Engine
    {
        private string model;
        private string power;
        private string displacement;
        private string efficiency;

        public Engine(string model, string power, string displacement, string efficiency)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{Model}:");
            builder.AppendLine($"    Power: {Power}");
            builder.AppendLine($"    Displacement: {Displacement}");
            builder.AppendLine($"    Efficiency: {Efficiency}");

            return builder.ToString().TrimEnd();

        }
    }
}
