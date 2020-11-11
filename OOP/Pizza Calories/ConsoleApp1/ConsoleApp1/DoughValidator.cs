using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class DoughValidator
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTypes;

        public static bool IsValidFlourType(string type)
        {
            Initialize();
            return flourTypes.ContainsKey(type.ToLower());
        }

        public static bool IsValidBakingType(string type)
        {
            Initialize();
            return bakingTypes.ContainsKey(type.ToLower());
        }

        public static double GetFlourModifier(string type)
        {
            Initialize();
            return flourTypes[type.ToLower()];
        }


        public static double GetBakingTypesModifier(string type)
        {
            Initialize();
            return bakingTypes[type.ToLower()];
        }

        private static void Initialize()
        {
            if (flourTypes != null && bakingTypes != null)
            {
                return;
            }

            flourTypes = new Dictionary<string, double>();
            bakingTypes = new Dictionary<string, double>();

            flourTypes.Add("white", 1.5);
            flourTypes.Add("wholegrain", 1.0);
            bakingTypes.Add("crispy", 0.9);
            bakingTypes.Add("chewy", 1.1);
            bakingTypes.Add("homemade", 1.0);
        }
    }
}
