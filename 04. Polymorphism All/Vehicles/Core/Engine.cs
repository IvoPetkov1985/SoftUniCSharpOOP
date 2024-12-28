using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core
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
            vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            try
            {
                vehicles.Add(CreateVehicle());
                vehicles.Add(CreateVehicle());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
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
                    Console.WriteLine(ex.Message);
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

        private void ProcessCommand(string[] tokens)
        {
            string action = tokens[0];
            string type = tokens[1];
            double value = double.Parse(tokens[2]);

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            switch (action)
            {
                case "Drive":
                    writer.WriteLine(vehicle.Drive(value, true));
                    break;
                case "Refuel":
                    vehicle.Refuel(value);
                    break;
            }
        }
    }
}
