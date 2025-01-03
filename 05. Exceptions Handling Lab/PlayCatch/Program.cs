int[] ints = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int counter = 0;

string commandLine = Console.ReadLine();

while (true)
{
    string[] tokens = commandLine
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = tokens[0];

    try
    {
        switch (command)
        {
            case "Replace":
                int replaceIndex = int.Parse(tokens[1]);
                int element = int.Parse(tokens[2]);
                ints[replaceIndex] = element;
                break;
            case "Print":
                int startIndex = int.Parse(tokens[1]);
                int endIndex = int.Parse(tokens[2]);
                List<int> resultInts = new List<int>();
                for (int i = startIndex; i <= endIndex; i++)
                {
                    resultInts.Add(ints[i]);
                }
                Console.WriteLine(string.Join(", ", resultInts));
                break;
            case "Show":
                int showIndex = int.Parse(tokens[1]);
                Console.WriteLine(ints[showIndex]);
                break;
        }
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        counter++;
    }
    catch (FormatException)
    {
        Console.WriteLine("The variable is not in the correct format!");
        counter++;
    }

    if (counter == 3)
    {
        break;
    }

    commandLine = Console.ReadLine();
}

Console.WriteLine(string.Join(", ", ints));
