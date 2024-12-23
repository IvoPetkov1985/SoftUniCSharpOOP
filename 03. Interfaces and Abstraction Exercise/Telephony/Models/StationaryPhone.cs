using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (IsNumberValid(phoneNumber) == false)
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool IsNumberValid(string phoneNumber)
            => phoneNumber.All(c => char.IsDigit(c));
    }
}
