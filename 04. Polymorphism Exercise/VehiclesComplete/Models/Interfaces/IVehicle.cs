namespace VehiclesComplete.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double TankCapacity { get; }

        string Drive(double distanceInKm, bool isIncreasedConsumption);

        void Refuel(double amountInL);
    }
}
