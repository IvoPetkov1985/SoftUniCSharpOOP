namespace CollectionHierarchy2.Models.Contracts
{
    public interface IMyList : IAddRemoveCollection
    {
        int Used { get; }
    }
}
