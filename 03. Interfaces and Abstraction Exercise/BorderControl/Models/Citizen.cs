﻿using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable, IHuman
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }
    }
}
