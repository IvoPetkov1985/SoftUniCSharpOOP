using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private const int InsertRemoveIndex = 0;
        private readonly IList<string> items;

        public MyList()
        {
            items = new List<string>();
        }

        public int Add(string item)
        {
            items.Insert(InsertRemoveIndex, item);
            return InsertRemoveIndex;
        }

        public string Remove()
        {
            string item = items.ElementAt(InsertRemoveIndex);
            items.Remove(item);
            return item;
        }

        public int Used { get { return items.Count; } }
    }
}
