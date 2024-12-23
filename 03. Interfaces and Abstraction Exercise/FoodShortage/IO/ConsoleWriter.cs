using FoodShortage.IO.Interfaces;

namespace FoodShortage.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object text)
            => Console.WriteLine(text);
    }
}
