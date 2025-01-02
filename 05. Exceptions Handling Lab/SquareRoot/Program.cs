try
{
	ProcessCommand();
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}

static void ProcessCommand()
{
	int inputNumber = int.Parse(Console.ReadLine());

	if (inputNumber < 0)
	{
		throw new ArgumentException("Invalid number.");
	}

    Console.WriteLine(Math.Sqrt(inputNumber));
}
