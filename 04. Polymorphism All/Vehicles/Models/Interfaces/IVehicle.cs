namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double IncreasedConsumption { get; }

        string Drive(double distance, bool isIncreasedConsumption);

        void Refuel(double amount);
    }
}
