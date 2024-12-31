using Telephony2.Models.Contracts;

namespace Telephony2.Models
{
    public class StationaryPhone : IStationaryPhone
    {
        private const string InvalidNumberMessage = "Invalid number!";

        public string Call(string phoneNumber)
        {
            if (IsStationaryNumberValid(phoneNumber) == false)
            {
                throw new ArgumentException(InvalidNumberMessage);
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool IsStationaryNumberValid(string phoneNumber)
        {
            if (phoneNumber.All(c => char.IsDigit(c)) == false)
            {
                return false;
            }

            return true;
        }
    }
}
