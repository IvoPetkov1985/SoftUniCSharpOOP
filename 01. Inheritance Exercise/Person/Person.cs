using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!");
                }

                age = value;
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} -> Name: {Name}, Age: {Age}";
        }
    }
}
