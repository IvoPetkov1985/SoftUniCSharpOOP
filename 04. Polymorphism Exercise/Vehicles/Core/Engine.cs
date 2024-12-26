using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;
using Vehicles.VehicleFactory.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory factory;
        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory factory)
        {
            this.reader = reader;
            this.writer = writer;
            this.factory = factory;
            vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int commandsCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string inputLine = reader.ReadLine();
                string[] inputTokens = inputLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = inputTokens[0];
                string type = inputTokens[1];
                double amount = double.Parse(inputTokens[2]);

                try
                {
                    IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);

                    if (action == "Drive")
                    {
                        writer.WriteLine(vehicle.Drive(amount));
                    }
                    else
                    {
                        vehicle.Refuel(amount);
                    }
                }
                catch (Exception ex)
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
            string vehicleInfo = reader.ReadLine();
            string[] tokens = vehicleInfo
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = tokens[0];
            double fuelQuantity = double.Parse(tokens[1]);
            double fuelConsumption = double.Parse(tokens[2]);

            IVehicle vehicle = factory.Create(type, fuelQuantity, fuelConsumption);
            return vehicle;
        }
    }
}
