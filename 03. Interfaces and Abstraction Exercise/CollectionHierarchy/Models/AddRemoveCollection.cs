using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private const int InsertIndex = 0;
        private readonly IList<string> items;

        public AddRemoveCollection()
        {
            items = new List<string>();
        }

        public int Add(string item)
        {
            items.Insert(InsertIndex, item);
            return InsertIndex;
        }

        public string Remove()
        {
            string item = items.ElementAt(items.Count - 1);
            items.Remove(item);
            return item;
        }
    }
}
