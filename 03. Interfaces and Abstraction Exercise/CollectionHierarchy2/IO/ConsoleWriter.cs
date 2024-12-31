using CollectionHierarchy2.IO.Contracts;

namespace CollectionHierarchy2.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
            => Console.WriteLine(text);

    }
}
