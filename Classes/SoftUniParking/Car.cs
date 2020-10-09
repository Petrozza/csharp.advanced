using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Make: {Make}");
            builder.AppendLine($"Model: {Model}");
            builder.AppendLine($"HorsePower: {HorsePower}");
            builder.AppendLine($"RegistrationNumber: {RegistrationNumber}");

            return builder.ToString().TrimEnd();

        }
    }
}
