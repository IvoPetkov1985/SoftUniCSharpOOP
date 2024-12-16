namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            List<Person> people = new();

            for (int i = 0; i < peopleCount; i++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);

                Person person = new(firstName, lastName, age);

                people.Add(person);
            }

            people.OrderBy(x => x.FirstName)
                .ThenBy(x => x.Age)
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
