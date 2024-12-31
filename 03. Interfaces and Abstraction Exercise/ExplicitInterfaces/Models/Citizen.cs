﻿using ExplicitInterfaces.Models.Interfaces;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        string IResident.GetName()
            => $"Mr/Ms/Mrs {Name}";

        string IPerson.GetName()
        {
            return $"{Name}";
        }
    }
}
