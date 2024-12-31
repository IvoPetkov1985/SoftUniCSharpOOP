using CollectionHierarchy2.Models.Contracts;

namespace CollectionHierarchy2.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private const int AddIndex = 0;

        private readonly List<string> items;

        public AddRemoveCollection()
        {
            items = new List<string>();
        }

        public int Add(string item)
        {
            items.Insert(AddIndex, item);
            return AddIndex;
        }

        public string Remove()
        {
            string item = items[^1];
            items.Remove(item);
            return item;
        }
    }
}
