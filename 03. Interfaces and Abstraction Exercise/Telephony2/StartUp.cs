using Telephony2.Core;
using Telephony2.Core.Contracts;
using Telephony2.IO;
using Telephony2.IO.Contracts;
using Telephony2.Models;
using Telephony2.Models.Contracts;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
ISmartphone smartphone = new Smartphone();
IStationaryPhone stationaryPhone = new StationaryPhone();

IEngine engine = new Engine(reader, writer, smartphone, stationaryPhone);
engine.Run();
