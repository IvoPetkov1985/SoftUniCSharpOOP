using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string[] vehicleTokens);
    }
}
