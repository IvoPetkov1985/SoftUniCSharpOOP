namespace ShoppingSpree.Models
{
    public class Person
    {
        private const string EmptyNameErrorMessage = "Name cannot be empty";
        private const string NegativeMoneyErrorMessage = "Money cannot be negative";

        private string name;
        private decimal money;
        private readonly List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
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

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeMoneyErrorMessage);
                }

                money = value;
            }
        }

        public void AddProduct(Product product)
        {
            if (product.Cost > Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                bagOfProducts.Add(product);
                Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            if (bagOfProducts.Any())
            {
                return $"{this.Name} - {string.Join(", ", bagOfProducts.Select(p => p.Name))}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}
