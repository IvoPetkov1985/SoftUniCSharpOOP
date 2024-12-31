using CollectionHierarchy2.Core.Contracts;
using CollectionHierarchy2.IO.Contracts;
using CollectionHierarchy2.Models.Contracts;

namespace CollectionHierarchy2.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAddCollection addCollection;
        private readonly IAddRemoveCollection addRemoveCollection;
        private readonly IMyList myList;

        public Engine(
            IReader reader,
            IWriter writer,
            IAddCollection addCollection,
            IAddRemoveCollection addRemoveCollection,
            IMyList myList)
        {
            this.reader = reader;
            this.writer = writer;
            this.addCollection = addCollection;
            this.addRemoveCollection = addRemoveCollection;
            this.myList = myList;
        }

        public void Run()
        {
            string[] inputElements = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICollection<int> acIndices = new List<int>();
            ICollection<int> arcIndices = new List<int>();
            ICollection<int> mlIndices = new List<int>();

            foreach (string element in inputElements)
            {
                acIndices.Add(addCollection.Add(element));
                arcIndices.Add(addRemoveCollection.Add(element));
                mlIndices.Add(myList.Add(element));
            }

            ICollection<string> arcRemoved = new List<string>();
            ICollection<string> mlRemoved = new List<string>();

            int itemsToRemove = int.Parse(reader.ReadLine());

            for (int i = 0; i < itemsToRemove; i++)
            {
                arcRemoved.Add(addRemoveCollection.Remove());
                mlRemoved.Add(myList.Remove());
            }

            writer.WriteLine(string.Join(" ", acIndices));
            writer.WriteLine(string.Join(" ", arcIndices));
            writer.WriteLine(string.Join(" ", mlIndices));
            writer.WriteLine(string.Join(" ", arcRemoved));
            writer.WriteLine(string.Join(" ", mlRemoved));
        }
    }
}
