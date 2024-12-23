using BorderControl.Core.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core
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
            string inputLine = reader.ReadLine();
            List<IIdentifiable> identifiables = new();

            while (inputLine != "End")
            {
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string identifier = tokens[1];
                    IIdentifiable robot = new Robot(model, identifier);
                    identifiables.Add(robot);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string identifier = tokens[2];
                    IIdentifiable citizen = new Citizen(name, age, identifier);
                    identifiables.Add(citizen);
                }

                inputLine = reader.ReadLine();
            }

            string problemSuffix = reader.ReadLine();

            foreach (IIdentifiable identifiable in identifiables)
            {
                if (identifiable.Id.EndsWith(problemSuffix))
                {
                    writer.WriteLine(identifiable.Id);
                }
            }
        }
    }
}
