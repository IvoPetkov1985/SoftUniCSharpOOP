using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;
        private readonly IList<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IFoodFactory foodFactory, IAnimalFactory animalFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string inputLine = reader.ReadLine();

            while (inputLine != "End")
            {
                string[] animalTokens = inputLine
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IAnimal animal = null;

                try
                {
                    animal = CreateAnimal(animalTokens);
                    writer.WriteLine(animal.ProduceSound());
                    IFood food = CreateFood();
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }

                animals.Add(animal);

                inputLine = reader.ReadLine();
            }

            foreach (IAnimal animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }

        private IAnimal CreateAnimal(string[] animalTokens)
        {
            IAnimal animal = animalFactory.Create(animalTokens);
            return animal;
        }

        private IFood CreateFood()
        {
            string foodInfo = reader.ReadLine();
            string[] foodTokens = foodInfo
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            IFood food = foodFactory.Create(type, quantity);
            return food;
        }
    }
}
