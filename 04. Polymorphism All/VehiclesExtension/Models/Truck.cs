namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double TruckIncreasedConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double IncreasedConsumption { get { return TruckIncreasedConsumption; } }

        public override void Refuel(double amount)
        {
            if (amount > TankCapacity - FuelQuantity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            base.Refuel(amount * 0.95);
        }
    }
}
