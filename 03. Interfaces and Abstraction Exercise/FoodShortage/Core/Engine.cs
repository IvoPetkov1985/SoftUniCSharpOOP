using FoodShortage.Core.Interfaces;
using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Core
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
            int peopleCount = int.Parse(reader.ReadLine());
            IList<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < peopleCount; i++)
            {
                string commandLine = reader.ReadLine();
                string[] tokens = commandLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (tokens.Length == 3)
                {
                    string groupName = tokens[2];
                    IBuyer rebel = new Rebel(name, age, groupName);
                    buyers.Add(rebel);
                }
                else
                {
                    string id = tokens[2];
                    string birthdate = tokens[3];
                    IBuyer citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
            }

            string personName = reader.ReadLine();

            while (personName != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == personName);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                personName = reader.ReadLine();
            }

            writer.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
