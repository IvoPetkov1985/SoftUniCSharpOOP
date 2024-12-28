using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.Models;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string[] vehicleTokens)
        {
            string type = vehicleTokens[0];
            double fuelQuantity = double.Parse(vehicleTokens[1]);
            double fuelConsumption = double.Parse(vehicleTokens[2]);
            double tankCapacity = double.Parse(vehicleTokens[3]);

            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCapacity);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
