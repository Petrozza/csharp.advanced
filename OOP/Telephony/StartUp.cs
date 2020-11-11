using System;

namespace Telephony
{
    public class StartUp
    {
        public static void Main()
        {
            
            string[] numbers = Console.ReadLine().Split();
            string[] sitesUrl = Console.ReadLine().Split();
            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();
            
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Calling(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Calling(number));
                    }
                    else
                    {
                        throw new Exception("Invalid number!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var site in sitesUrl)
            {
                try
                {
                    Console.WriteLine(smartphone.Browsing(site));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
