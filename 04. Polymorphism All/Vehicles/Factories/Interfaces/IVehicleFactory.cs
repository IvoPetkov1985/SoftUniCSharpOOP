using Vehicles.Models.Interfaces;

namespace Vehicles.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string[] vehicleArgs);
    }
}
