using System.IO;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle veh = new Motorcycle(100, 25);
            veh.Drive(12);
            System.Console.WriteLine(veh.Fuel);
        }
    }
}
