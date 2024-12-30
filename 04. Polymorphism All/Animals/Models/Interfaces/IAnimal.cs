namespace Animals.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }

        string FavouriteFood { get; }

        string ExplainSelf();
    }
}
