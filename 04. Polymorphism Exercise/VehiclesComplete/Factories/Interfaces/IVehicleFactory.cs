using VehiclesComplete.Models.Interfaces;

namespace VehiclesComplete.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
