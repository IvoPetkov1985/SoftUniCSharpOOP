using CollectionHierarchy2.Models.Contracts;

namespace CollectionHierarchy2.Models
{
    public class MyList : IMyList
    {
        private readonly Stack<string> items;

        public MyList()
        {
            items = new Stack<string>();
        }

        public int Used { get { return items.Count; } }

        public int Add(string item)
        {
            items.Push(item);
            return 0;
        }

        public string Remove()
        {
            return items.Pop();
        }
    }
}
