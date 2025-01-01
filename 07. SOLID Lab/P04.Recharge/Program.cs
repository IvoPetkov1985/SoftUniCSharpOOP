using P04.Recharge.Contracts;
using System;
using System.Collections.Generic;

namespace P04.Recharge
{
    class Program
    {
        static void Main()
        {
            Robot robot1 = new("1515", 16);
            robot1.Recharge();
            robot1.Work(12);
            Console.WriteLine(robot1.CurrentPower);

            Robot robot2 = new("6688", 20);
            robot2.Recharge();
            robot2.Work(19);

            ICollection<IRechargeable> robots = new List<IRechargeable>
            {
                robot1,
                robot2
            };

            RechargeStation station = new(robots);
            station.Recharge();

            Console.WriteLine(robot1.CurrentPower);
            Console.WriteLine(robot2.CurrentPower);
        }
    }
}
