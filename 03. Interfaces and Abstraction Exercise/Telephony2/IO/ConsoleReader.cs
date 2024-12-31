using Telephony2.IO.Contracts;

namespace Telephony2.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();
    }
}
