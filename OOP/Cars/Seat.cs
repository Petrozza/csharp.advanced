﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public string Model { get; private set; }

        public string Color { get; private set; }

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

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
            sb.AppendLine($"{Color} Seat {Model}");
            sb.AppendLine(Start());
            sb.AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
