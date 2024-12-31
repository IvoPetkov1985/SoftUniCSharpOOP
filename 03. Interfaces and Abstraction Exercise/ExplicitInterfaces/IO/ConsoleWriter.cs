using ExplicitInterfaces.IO.Interfaces;

namespace ExplicitInterfaces.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
            => Console.WriteLine(text);
    }
}
