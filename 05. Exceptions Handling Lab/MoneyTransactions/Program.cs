Dictionary<int, double> bankAccounts = new();

string bankAccountsInfo = Console.ReadLine();
string[] accounts = bankAccountsInfo.Split(",", StringSplitOptions.RemoveEmptyEntries);

foreach (string accountInfo in accounts)
{
    string[] accountTokens = accountInfo
        .Split("-", StringSplitOptions.RemoveEmptyEntries);

    int accountNumber = int.Parse(accountTokens[0]);
    double accountBalance = double.Parse(accountTokens[1]);

    bankAccounts.Add(accountNumber, accountBalance);
}

string commandLine = Console.ReadLine();

while (commandLine != "End")
{
	string[] commandTokens = commandLine
		.Split(" ", StringSplitOptions.RemoveEmptyEntries);	

	try
	{
        string command = commandTokens[0];
        int accountNumber = int.Parse(commandTokens[1]);

        if (!bankAccounts.ContainsKey(accountNumber))
        {
            throw new ArgumentException("Invalid account!");
        }

        double sum = double.Parse(commandTokens[2]);

        switch (command)
        {
            case "Deposit":
                bankAccounts[accountNumber] += sum;
                break;
            case "Withdraw":
                if (sum > bankAccounts[accountNumber])
                {
                    throw new InvalidOperationException("Insufficient balance!");
                }
                bankAccounts[accountNumber] -= sum;
                break;
            default:
                throw new ArgumentException("Invalid command!");
        }

        Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:F2}");
    }
	catch (ArgumentException ex)
	{
        Console.WriteLine(ex.Message);
	}
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }

    commandLine = Console.ReadLine();
}
