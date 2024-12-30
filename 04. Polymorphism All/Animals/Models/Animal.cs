using Animals.Models.Interfaces;

namespace Animals.Models
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string Name { get; private set; }

        public string FavouriteFood { get; private set; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my favourite food is {FavouriteFood}";
        }
    }
}
