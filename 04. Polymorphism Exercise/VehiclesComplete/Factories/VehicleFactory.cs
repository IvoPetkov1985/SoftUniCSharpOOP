using VehiclesComplete.Factories.Interfaces;
using VehiclesComplete.Models;
using VehiclesComplete.Models.Interfaces;

namespace VehiclesComplete.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (type == "Car")
            {
                return new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
