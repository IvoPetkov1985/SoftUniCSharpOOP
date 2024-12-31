using CollectionHierarchy2.IO.Contracts;

namespace CollectionHierarchy2.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();
    }
}
