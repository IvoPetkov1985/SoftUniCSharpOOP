using VehiclesComplete.Core.Interfaces;
using VehiclesComplete.Factories.Interfaces;
using VehiclesComplete.Models.Interfaces;

namespace VehiclesComplete.Core
{
    public class Engine : IEngine
    {
        private readonly IVehicleFactory vehicleFactory;
        private readonly ICollection<IVehicle> vehicles;

        public Engine(IVehicleFactory vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;
            this.vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (IVehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] vehicleTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = vehicleTokens[0];
            double fuelQuantity = double.Parse(vehicleTokens[1]);
            double fuelConsumption = double.Parse(vehicleTokens[2]);
            double tankCapacity = double.Parse(vehicleTokens[3]);

            IVehicle vehicle = vehicleFactory.Create(type, fuelQuantity, fuelConsumption, tankCapacity);
            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] commandTokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];
            string type = commandTokens[1];
            double value = double.Parse(commandTokens[2]);

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if (command == "Drive")
            {
                Console.WriteLine(vehicle.Drive(value, true));
            }
            else if (command == "Refuel")
            {
                vehicle.Refuel(value);
            }
            else if (command == "DriveEmpty")
            {
                Console.WriteLine(vehicle.Drive(value, false));
            }
        }
    }
}
