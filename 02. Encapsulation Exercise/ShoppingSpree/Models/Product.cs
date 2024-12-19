namespace ShoppingSpree.Models
{
    public class Product
    {
        private const string EmptyNameErrorMessage = "Name cannot be empty";
        private const string NegativeCostErrorMessage = "Money cannot be negative";

        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(EmptyNameErrorMessage);
                }

                name = value;
            }
        }

        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeCostErrorMessage);
                }

                cost = value;
            }
        }
    }
}
