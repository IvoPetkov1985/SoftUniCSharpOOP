﻿using VehiclesExtension.Core;
using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Factories;

namespace VehiclesExtension
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