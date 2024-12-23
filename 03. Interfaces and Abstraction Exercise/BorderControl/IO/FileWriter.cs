using BorderControl.IO.Interfaces;

namespace BorderControl.IO
{
    internal class FileWriter : IWriter
    {
        public void WriteLine(string text)
        {
            string path = "../../../test.txt";

            using StreamWriter stream = new StreamWriter(path, true);

            stream.WriteLine(text);
        }
    }
}
