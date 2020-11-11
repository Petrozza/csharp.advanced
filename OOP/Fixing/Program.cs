using System;
using System.Net.Http.Headers;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ddd = Console.ReadLine();
                throw new ArgumentNullException("шитня");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
