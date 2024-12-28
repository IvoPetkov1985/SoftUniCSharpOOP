namespace WildFarm.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        double FoodEaten { get; }

        string ProduceSound();

        void Eat(IFood food);
    }
}
