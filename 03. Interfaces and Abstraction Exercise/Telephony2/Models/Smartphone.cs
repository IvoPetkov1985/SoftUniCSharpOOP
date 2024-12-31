using Telephony2.Models.Contracts;

namespace Telephony2.Models
{
    public class Smartphone : ISmartphone
    {
        private const string InvalidNumberMessage = "Invalid number!";
        private const string InvalidUrlMessage = "Invalid URL!";

        public string Browse(string url)
        {
            if (IsUrlValid(url) == false)
            {
                throw new ArgumentException(InvalidUrlMessage);
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (IsPhoneNumberValid(phoneNumber) == false)
            {
                throw new ArgumentException(InvalidNumberMessage);
            }

            return $"Calling... {phoneNumber}";
        }

        private static bool IsPhoneNumberValid(string phoneNumber)
        {
            if (phoneNumber.All(c => char.IsDigit(c)) == false)
            {
                return false;
            }

            return true;
        }

        private static bool IsUrlValid(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                return false;
            }

            return true;
        }
    }
}
