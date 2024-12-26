namespace VehiclesComplete.Models
{
    public class Truck : Vehicle
    {
        private const double TruckIncreasedConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, TruckIncreasedConsumption)
        {
        }

        public override void Refuel(double amountInL)
        {
            if (amountInL + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amountInL} fuel in the tank");
            }

            base.Refuel(amountInL * 0.95);
        }
    }
}
