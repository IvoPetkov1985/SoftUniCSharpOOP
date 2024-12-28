using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public virtual double FoodEaten { get; private set; }

        protected abstract IReadOnlyCollection<Type> PreferedFoods { get; }

        protected abstract double WeightMofidier { get; }

        public void Eat(IFood food)
        {
            if (!PreferedFoods.Any(pf => pf.Name == food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightMofidier;

            FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, ";
        }
    }
}
