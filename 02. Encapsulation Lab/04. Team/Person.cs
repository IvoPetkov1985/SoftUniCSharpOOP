namespace PersonsInfo
{
    public class Person
    {
        private const string FirstNameErrorMessage = "First name cannot contain fewer than 3 symbols!";
        private const string LastNameErrorMessage = "Last name cannot contain fewer than 3 symbols!";
        private const string AgeErrorMessage = "Age cannot be zero or a negative integer!";

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if (value != null && value.Length < 3)
                {
                    throw new ArgumentException(FirstNameErrorMessage);
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (value != null && value.Length < 3)
                {
                    throw new ArgumentException(LastNameErrorMessage);
                }

                lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(AgeErrorMessage);
                }

                age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }
            private set
            {
                salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                Salary += Salary * percentage / 200;
            }
            else
            {
                Salary += Salary * percentage / 100;
            }

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:f2} leva.";
        }
    }
}
