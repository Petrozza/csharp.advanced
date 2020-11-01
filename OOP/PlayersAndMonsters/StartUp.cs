using System;
namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new Elf("ssss", 44);
            Console.WriteLine(hero);
        }
    }
}