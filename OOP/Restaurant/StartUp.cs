namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Product ddd = new Dessert("tolumba", 5, 5, 1000);
            System.Console.WriteLine($"{ddd.Name} за {ddd.Price} леа");
            System.Console.WriteLine($"{ddd.Name} за {ddd.Price} леа");
            System.Console.WriteLine($"{ddd.Name} за {ddd.Price} леа");
            System.Console.WriteLine($"{ddd.Name} за {ddd.Price} леа");
            System.Console.WriteLine($"{ddd.Name} за {ddd.Price} леа");
        }
    }
}