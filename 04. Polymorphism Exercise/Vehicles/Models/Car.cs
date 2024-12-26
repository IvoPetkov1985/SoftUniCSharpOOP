namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double CarAdditionalConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AdditionalConsumption => CarAdditionalConsumption;
    }
}
