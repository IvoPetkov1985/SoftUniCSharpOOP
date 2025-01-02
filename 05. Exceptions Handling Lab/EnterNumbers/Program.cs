ICollection<int> ints = new List<int>();

int start = 1;
int end = 100;

while (ints.Count < 10)
{
    try
    {
        int number = ReadNumber(start, end);

        ints.Add(number);

        start = number;
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(", ", ints));

int ReadNumber(int start, int end)
{
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int value))
    {
        throw new FormatException("Invalid Number!");
    }
    else if (value <= start || value >= end)
    {
        throw new ArgumentException($"Your number is not in range {start} - {end}!");
    }

    return value;
}
