namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double BusIncreasedConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double IncreasedConsumption { get { return BusIncreasedConsumption; } }
    }
}
