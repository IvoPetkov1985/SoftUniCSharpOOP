namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inputLine = Console.ReadLine();
                string[] tokens = inputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                decimal salary = decimal.Parse(tokens[3]);

                try
                {
                    Person person = new(firstName, lastName, age, salary);
                    Console.WriteLine(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
