using ExplicitInterfaces.Core;
using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.IO;
using ExplicitInterfaces.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();

IEngine engine = new Engine(reader, writer);
engine.Run();
