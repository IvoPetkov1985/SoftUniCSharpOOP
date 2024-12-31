using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.IO.Interfaces;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<Citizen> citizens;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.citizens = new List<Citizen>();
        }

        public void Run()
        {
            string citizenInfo = reader.ReadLine();

            while (citizenInfo != "End")
            {
                string[] tokens = citizenInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                ProcessCommand(tokens);

                citizenInfo = reader.ReadLine();
            }

            foreach (Citizen citizen in citizens)
            {
                writer.WriteLine(((IPerson)citizen).GetName());
                writer.WriteLine(((IResident)citizen).GetName());
            }
        }

        private void ProcessCommand(string[] tokens)
        {
            string name = tokens[0];
            string country = tokens[1];
            int age = int.Parse(tokens[2]);

            Citizen citizen = new(name, age, country);
            citizens.Add(citizen);
        }
    }
}
