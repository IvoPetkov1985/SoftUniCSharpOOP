using Telephony2.IO.Contracts;

namespace Telephony2.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
            => Console.WriteLine(text);
    }
}
