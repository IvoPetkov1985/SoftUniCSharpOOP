namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string commandLine = Console.ReadLine();
                string[] tokens = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                decimal salary = decimal.Parse(tokens[3]);

                try
                {
                    Person person = new(firstName, lastName, age, salary);
                    persons.Add(person);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Team team = new("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team);
        }
    }
}
