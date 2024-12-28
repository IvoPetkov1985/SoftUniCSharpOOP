namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double TruckIncreasedConsumption = 1.6;
        private const double TruckRealCapacity = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double IncreasedConsumption { get { return TruckIncreasedConsumption; } }

        public override void Refuel(double amount)
        {
            base.Refuel(amount * TruckRealCapacity);
        }
    }
}
