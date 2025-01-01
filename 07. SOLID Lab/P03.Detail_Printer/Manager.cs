using P03.Detail_Printer.Contracts;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee, IEmployee
    {
        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string PrintDetails()
        {
            StringBuilder builder = new();
            builder.AppendLine(Name);

            foreach (string document in Documents)
            {
                builder.AppendLine(document);
            }

            return builder.ToString().TrimEnd();
        }
    }
}
