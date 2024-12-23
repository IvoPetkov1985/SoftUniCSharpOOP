using Telephony.Core.Interfaces;
using Telephony.IO.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] urls = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (string phoneNumber in phoneNumbers)
            {
                ICallable phone = null;

                if (phoneNumber.Length == 7)
                {
                    phone = new StationaryPhone();
                }
                else
                {
                    phone = new Smartphone();
                }

                try
                {
                    writer.WriteLine(phone.Call(phoneNumber));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (string url in urls)
            {
                IBrowsable smartphone = new Smartphone();

                try
                {
                    writer.WriteLine(smartphone.Browse(url));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
