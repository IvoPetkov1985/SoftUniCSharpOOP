using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private readonly IVehicleFactory vehicleFactory;
        private readonly ICollection<IVehicle> vehicles;

        public Engine(IVehicleFactory vehicleFactory)
        {
            this.vehicleFactory = vehicleFactory;
            vehicles = new List<IVehicle>();
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
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }

        private void ProcessCommand()
        {
            string[] commandTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];
            string vehicleType = commandTokens[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if (command == "Drive")
            {
                double distance = double.Parse(commandTokens[2]);
                Console.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "DriveEmpty")
            {
                double distance = double.Parse(commandTokens[2]);
                Console.WriteLine(vehicle.Drive(distance, false));
            }
            else if (command == "Refuel")
            {
                double fuelAmount = double.Parse(commandTokens[2]);
                vehicle.Refuel(fuelAmount);
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] tokens = Console.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            return vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));
        }
    }
}
