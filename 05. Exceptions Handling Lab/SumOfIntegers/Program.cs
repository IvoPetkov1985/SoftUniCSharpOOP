string[] inputTokens = Console.ReadLine()
    .Split(" ");

ICollection<int> ints = new List<int>();

foreach (string token in inputTokens)
{
    try
    {
        ints.Add(int.Parse(token));
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{token}' is in wrong format!");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{token}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{token}' processed - current sum: {ints.Sum()}");
    }
}

Console.WriteLine($"The total sum of all integers is: {ints.Sum()}");
