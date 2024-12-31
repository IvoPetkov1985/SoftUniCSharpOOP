namespace Telephony2.Models.Contracts
{
    public interface ISmartphone : IStationaryPhone
    {
        string Browse(string url);
    }
}
