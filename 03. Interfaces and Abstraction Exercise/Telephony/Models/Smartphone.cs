using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (IsUrlValid(url) == false)
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (IsNumberValid(phoneNumber) == false)
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }

        private static bool IsNumberValid(string phoneNumber)
            => phoneNumber.All(c => char.IsDigit(c));

        private static bool IsUrlValid(string url)
            => url.All(c => !char.IsDigit(c));
    }
}
