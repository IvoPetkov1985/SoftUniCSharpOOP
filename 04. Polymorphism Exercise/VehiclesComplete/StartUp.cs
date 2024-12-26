using VehiclesComplete.Core;
using VehiclesComplete.Core.Interfaces;
using VehiclesComplete.Factories;

namespace VehiclesComplete
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new VehicleFactory());
            engine.Run();
        }
    }
}
