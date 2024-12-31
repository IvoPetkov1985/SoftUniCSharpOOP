using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        private readonly IAddCollection addCollection;
        private readonly IAddRemoveCollection addRemoveCollection;
        private readonly IMyList myList;

        public Engine(
            IAddCollection addCollection, 
            IAddRemoveCollection addRemoveCollection, 
            IMyList myList)
        {
            this.addCollection = addCollection;
            this.addRemoveCollection = addRemoveCollection;
            this.myList = myList;
        }

        public void Run()
        {
            string[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICollection<int> acIndices = new List<int>();
            ICollection<int> arcIndices = new List<int>();
            ICollection<int> mlIndices = new List<int>();

            foreach (string element in elements)
            {
                acIndices.Add(addCollection.Add(element));
                arcIndices.Add(addRemoveCollection.Add(element));
                mlIndices.Add(myList.Add(element));
            }

            int removeCount = int.Parse(Console.ReadLine());

            ICollection<string> arcRemoved = new List<string>();
            ICollection<string> mlRemoved = new List<string>();

            for (int i = 0; i < removeCount; i++)
            {
                arcRemoved.Add(addRemoveCollection.Remove());
                mlRemoved.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", acIndices));
            Console.WriteLine(string.Join(" ", arcIndices));
            Console.WriteLine(string.Join(" ", mlIndices));
            Console.WriteLine(string.Join(" ", arcRemoved));
            Console.WriteLine(string.Join(" ", mlRemoved));
        }
    }
}
