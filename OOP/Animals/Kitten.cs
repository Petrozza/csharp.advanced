
namespace Animals
{
    public class Kitten : Cat
    {
        private const string DEFAULT_GEMDER = "Female";
        public Kitten(string name, int age) : base(name, age, DEFAULT_GEMDER)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
