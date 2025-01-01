using P01.Stream_Progress.Contracts;
using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            IStreamable musicFile = new Music("Toto", "The Seventh One", 3000, 500);
            IStreamable pcFile = new File("text.txt", 20, 10);

            StreamProgressInfo progressInfo = new(musicFile);
            StreamProgressInfo fileProgressInfo = new(pcFile);

            Console.WriteLine(progressInfo.CalculateCurrentPercent());
            Console.WriteLine(fileProgressInfo.CalculateCurrentPercent());
        }
    }
}
