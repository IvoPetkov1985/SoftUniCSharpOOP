using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories.Interfaces;
using VehiclesExtension.IO.Interfaces;
using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;
        private readonly IList<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
            this.vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            try
            {
                vehicles.Add(CreateVehicle());
                vehicles.Add(CreateVehicle());
                vehicles.Add(CreateVehicle());
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }

            int commandsCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] commandTokens = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    ProcessCommand(commandTokens);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (IVehicle vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

        private IVehicle CreateVehicle()
        {
            string[] vehicleTokens = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle vehicle = vehicleFactory.Create(vehicleTokens);
            return vehicle;
        }

        private void ProcessCommand(string[] commandTokens)
        {
            string action = commandTokens[0];
            string vehicleType = commandTokens[1];
            double value = double.Parse(commandTokens[2]);

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            switch (action)
            {
                case "Drive":
                    writer.WriteLine(vehicle.Drive(value, true));
                    break;
                case "DriveEmpty":
                    writer.WriteLine(vehicle.Drive(value, false));
                    break;
                case "Refuel":
                    vehicle.Refuel(value);
                    break;
            }
        }
    }
}
