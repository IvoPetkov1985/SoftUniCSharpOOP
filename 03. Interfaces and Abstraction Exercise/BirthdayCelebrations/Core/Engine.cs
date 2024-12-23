using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string commandLine = reader.ReadLine();
            IList<IBirthable> birthables = new List<IBirthable>();

            while (commandLine != "End")
            {
                string[] tokens = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command)
                {
                    case "Citizen":
                        string citizenName = tokens[1];
                        int age = int.Parse(tokens[2]);
                        string citizenId = tokens[3];
                        string citizenBirthdate = tokens[4];
                        IBirthable citizen = new Citizen(citizenName, age, citizenId, citizenBirthdate);
                        birthables.Add(citizen);
                        break;

                    case "Pet":
                        string petName = tokens[1];
                        string petBirthdate = tokens[2];
                        IBirthable pet = new Pet(petName, petBirthdate);
                        birthables.Add(pet);
                        break;
                }

                commandLine = reader.ReadLine();
            }

            string birthYear = reader.ReadLine();

            foreach (IBirthable birthable in birthables)
            {
                if (birthable.Birthdate.EndsWith(birthYear))
                {
                    writer.WriteLine(birthable.Birthdate);
                }
            }
        }
    }
}
