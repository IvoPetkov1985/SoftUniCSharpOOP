using CollectionHierarchy2.Models.Contracts;

namespace CollectionHierarchy2.Models
{
    public class AddCollection : IAddCollection
    {
        private readonly Queue<string> items;

        public AddCollection()
        {
            items = new Queue<string>();
        }

        public int Add(string item)
        {
            items.Enqueue(item);
            return items.Count - 1;
        }
    }
}
