using ShoppingSpree.Models;

List<Person> people = new();
List<Product> products = new();

try
{
    string peopleInputLine = Console.ReadLine();
    string[] personMoneyTuples = peopleInputLine
        .Split(';', StringSplitOptions.RemoveEmptyEntries);

    foreach (string tuple in personMoneyTuples)
    {
        string[] personTokens = tuple
            .Split("=", StringSplitOptions.RemoveEmptyEntries);

        string name = personTokens[0];
        decimal money = decimal.Parse(personTokens[1]);

        Person person = new(name, money);
        people.Add(person);
    }

    string productsInputLine = Console.ReadLine();
    string[] productCostTuples = productsInputLine
        .Split(";", StringSplitOptions.RemoveEmptyEntries);

    foreach (string tuple in productCostTuples)
    {
        string[] productTokens = tuple
            .Split("=", StringSplitOptions.RemoveEmptyEntries);

        string name = productTokens[0];
        decimal cost = decimal.Parse(productTokens[1]);

        Product product = new(name, cost);
        products.Add(product);
    }

    string inputLine = Console.ReadLine();

    while (inputLine != "END")
    {
        string[] tokens = inputLine
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string personName = tokens[0];
        string productName = tokens[1];

        Person person = people.FirstOrDefault(p => p.Name == personName);
        Product product = products.FirstOrDefault(p => p.Name == productName);

        person.AddProduct(product);

        inputLine = Console.ReadLine();
    }

    foreach (Person person in people)
    {
        Console.WriteLine(person);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    return;
}
