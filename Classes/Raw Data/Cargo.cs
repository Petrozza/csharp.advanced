
namespace DefiningClasses
{
    public class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            GargoType = cargoType;
        }

        public int CargoWeight { get; set; }
        public string GargoType { get; set; }
    }
}
