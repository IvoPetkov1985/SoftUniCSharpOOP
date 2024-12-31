using Telephony2.Core.Contracts;
using Telephony2.IO.Contracts;
using Telephony2.Models.Contracts;

namespace Telephony2.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ISmartphone smartphone;
        private readonly IStationaryPhone stationaryPhone;

        public Engine(IReader reader, IWriter writer, ISmartphone smartphone, IStationaryPhone stationaryPhone)
        {
            this.reader = reader;
            this.writer = writer;
            this.smartphone = smartphone;
            this.stationaryPhone = stationaryPhone;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    CallNumber(phoneNumber);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            string[] urls = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string url in urls)
            {
                try
                {
                    BrowseUrl(url);
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private void CallNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 10)
            {
                writer.WriteLine(smartphone.Call(phoneNumber));
            }
            else
            {
                writer.WriteLine(stationaryPhone.Call(phoneNumber));
            }
        }

        private void BrowseUrl(string url)
        {
            writer.WriteLine(smartphone.Browse(url));
        }
    }
}
