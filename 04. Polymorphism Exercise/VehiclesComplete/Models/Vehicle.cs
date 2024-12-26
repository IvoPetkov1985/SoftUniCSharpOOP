using VehiclesComplete.Models.Interfaces;

namespace VehiclesComplete.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double increasedConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increasedConsumption = increasedConsumption;
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }

        public string Drive(double distance, bool isIncreasedConsumption = true)
        {
            double consumption = isIncreasedConsumption
                ? FuelConsumption + increasedConsumption
                : FuelConsumption;

            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amountInL)
        {
            if (amountInL <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (amountInL + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amountInL} fuel in the tank");
            }

            FuelQuantity += amountInL;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
