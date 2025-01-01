using P01.Stream_Progress.Contracts;

namespace P01.Stream_Progress
{
    public class File : IStreamable
    {
        public File(string name, int length, int bytesSent)
        {
            this.Name = name;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public string Name { get; private set; }

        public int Length { get; }

        public int BytesSent { get; }
    }
}
