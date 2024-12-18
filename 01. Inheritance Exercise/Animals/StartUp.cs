using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();

            while (animalType != "Beast!")
            {
                string animalInfo = Console.ReadLine();
                string[] tokens = animalInfo
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];

                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new(name, age, gender);
                            Console.WriteLine(dog);
                            break;
                        case "Frog":
                            Frog frog = new(name, age, gender);
                            Console.WriteLine(frog);
                            break;
                        case "Cat":
                            Cat cat = new(name, age, gender);
                            Console.WriteLine(cat);
                            break;
                        case "Kitten":
                            Kitten kitten = new(name, age);
                            Console.WriteLine(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new(name, age);
                            Console.WriteLine(tomcat);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animalType = Console.ReadLine();
            }
        }
    }
}
