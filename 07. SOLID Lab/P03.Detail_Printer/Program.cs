using P03.Detail_Printer.Contracts;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IEmployee employee = new Employee("Peter");
            IEmployee manager = new Manager("Anna", new List<string>() { "CV", "Schedule", "Working plan" });

            DetailsPrinter printer = new(new List<IEmployee>() { employee, manager });
            printer.PrintDetails();
        }
    }
}
