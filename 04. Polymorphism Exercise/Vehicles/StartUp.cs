using Vehicles.Core;
using Vehicles.Core.Interfaces;
using Vehicles.IO;
using Vehicles.VehicleFactory;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(
                new ConsoleReader(),
                new ConsoleWriter(),
                new Factory());
            engine.Run();
        }
    }
}
