using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual string PrintDetails()
        {
            return Name;
        }
    }
}
