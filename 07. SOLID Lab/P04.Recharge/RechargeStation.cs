using P04.Recharge.Contracts;
using System.Collections.Generic;

namespace P04.Recharge
{
    public class RechargeStation : IRechargeable
    {
        private ICollection<IRechargeable> robots;

        public RechargeStation(ICollection<IRechargeable> robots)
        {
            this.robots = robots;
        }

        public void Recharge()
        {
            foreach (IRechargeable rechargeable in robots)
            {
                rechargeable.Recharge();
            }
        }
    }
}
