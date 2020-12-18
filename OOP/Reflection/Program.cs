using System.Reflection;

namespace ReflectionDemo
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var type = typeof(Person);
            System.Console.WriteLine(type.GetProperty("Age").Name);
            System.Console.WriteLine(type.GetField("age"
                , BindingFlags.NonPublic | BindingFlags.Instance).Name);
        }
    }
}
