using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private IFoodFactory foodFactory;
        private IAnimalFactory animalFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(IFoodFactory foodFactory, IAnimalFactory animalFactory)
        {
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;

            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string commanaLine = Console.ReadLine();

            while (commanaLine != "End")
            {
                IAnimal animal = null;

                try
                {
                    animal = CreateAnimal(commanaLine);
                    Console.WriteLine(animal.ProduceSound());

                    IFood food = CreateFood();
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }

                animals.Add(animal);

                commanaLine = Console.ReadLine();
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private IAnimal CreateAnimal(string commandLine)
        {
            string[] animalArgs = commandLine
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = animalFactory.Create(animalArgs);
            return animal;
        }

        private IFood CreateFood()
        {
            string commandLine = Console.ReadLine();
            string[] foodArgs = commandLine
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            IFood food = foodFactory.Create(type, quantity);
            return food;
        }
    }
}
