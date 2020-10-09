﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Tires
    {
        public Tires(double tire1Pressure, int tire1Age, double tire2Pressure,
            int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Tire1Pressure = tire1Pressure;
            Tire2Pressure = tire2Pressure;
            Tire3Pressure = tire3Pressure;
            Tire4Pressure = tire4Pressure;
            Tire1Age = tire1Age;
            Tire2Age = tire2Age;
            Tire3Age = tire3Age;
            Tire4Age = tire4Age;
        }

        public double Tire1Pressure { get; set; }
        public int Tire1Age { get; set; }
        public double Tire2Pressure { get; set; }
        public int Tire2Age { get; set; }
        public double Tire3Pressure { get; set; }
        public int Tire3Age { get; set; }
        public double Tire4Pressure { get; set; }
        public int Tire4Age { get; set; }
    }
    
}

