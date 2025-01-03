ICollection<BankAccount> bankAccounts = new List<BankAccount>();

string accountsInfoLine = Console.ReadLine();
string[] accountsArr = accountsInfoLine
    .Split(",", StringSplitOptions.RemoveEmptyEntries);

foreach (string accountInfo in accountsArr)
{
    string[] accountTokens = accountInfo
        .Split("-", StringSplitOptions.RemoveEmptyEntries);

    int accountNum = int.Parse(accountTokens[0]);
    decimal accountBalance = decimal.Parse(accountTokens[1]);

    BankAccount account = new(accountNum, accountBalance);
    bankAccounts.Add(account);
}

string commandLine = Console.ReadLine();

while (commandLine != "End")
{
    string[] tokens = commandLine
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    try
    {
        ProcessCommand(tokens);
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

void ProcessCommand(string[] tokens)
{
    string command = tokens[0];
    int accountNumber = int.Parse(tokens[1]);

    BankAccount account = bankAccounts.FirstOrDefault(ba => ba.AccountNumber == accountNumber);

    if (account == null)
    {
        throw new ArgumentException("Invalid account!");
    }

    decimal sum = decimal.Parse(tokens[2]);

    if (command == "Deposit")
    {
        account.AccountBalance += sum;
    }
    else if (command == "Withdraw")
    {
        if (sum > account.AccountBalance)
        {
            throw new InvalidOperationException("Insufficient balance!");
        }

        account.AccountBalance -= sum;
    }
    else
    {
        throw new ArgumentException("Invalid command!");
    }

    Console.WriteLine(account.BalanceChangedInfo());
}

public class BankAccount
{
    public BankAccount(int accountNumber, decimal accountBalance)
    {
        AccountNumber = accountNumber;
        AccountBalance = accountBalance;
    }

    public int AccountNumber { get; private set; }

    public decimal AccountBalance { get; set; }

    public string BalanceChangedInfo()
    {
        return $"Account {AccountNumber} has new balance: {AccountBalance:F2}";
    }
}
