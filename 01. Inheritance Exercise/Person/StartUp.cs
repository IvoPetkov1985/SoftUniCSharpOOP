using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                if (age <= 15)
                {
                    Child child = new(name, age);
                    Console.WriteLine(child);
                }
                else
                {
                    Person person = new(name, age);
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
