using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public virtual double IncreasedConsumption { get; }

        public string Drive(double distance, bool isIncreasedConsumption = true)
        {
            double consumptionPerKm;

            if (isIncreasedConsumption == true)
            {
                consumptionPerKm = FuelConsumption + IncreasedConsumption;
            }
            else
            {
                consumptionPerKm = FuelConsumption;
            }

            if (distance * consumptionPerKm > FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumptionPerKm;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
