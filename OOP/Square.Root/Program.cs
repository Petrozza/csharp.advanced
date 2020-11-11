using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Square.Root
{
    class Program
    {
        public static double Sqrt(double value)
        {

            if (value < 0)

                throw new System.ArgumentOutOfRangeException("value",

                "Sqrt for negative numbers is undefined!");

            return Math.Sqrt(value);

        }

        static void Main()
        {

            try
            {

                Sqrt(-1);

            }

            catch (ArgumentOutOfRangeException ex)
            {

                Console.Error.WriteLine("Error: " + ex.Message);

                throw;

            }

        }
    }
}
