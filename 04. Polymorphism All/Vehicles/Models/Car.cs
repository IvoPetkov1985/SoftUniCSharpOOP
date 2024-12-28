namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CarIncreasedConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double IncreasedConsumption { get { return CarIncreasedConsumption; } }
    }
}
