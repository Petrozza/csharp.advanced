
namespace Wild.Farm.Models.Animals.Mammals
{
    public abstract class Felline : Mammal
    {
        protected Felline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
