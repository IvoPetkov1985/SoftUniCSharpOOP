namespace VehiclesComplete.Models
{
    public class Car : Vehicle
    {
        private const double CarIncreasedConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, CarIncreasedConsumption)
        {
        }
    }
}
