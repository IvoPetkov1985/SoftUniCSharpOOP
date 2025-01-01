using P04.Recharge.Contracts;

namespace P04.Recharge
{
    public abstract class Worker : IWorker
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}