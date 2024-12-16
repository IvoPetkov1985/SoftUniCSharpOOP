namespace PersonsInfo
{
    public class Person
    {
        private const string FirstNameErrorMsg = "First name cannot contain fewer than 3 symbols!";
        private const string LastNameErrorMsg = "Last name cannot contain fewer than 3 symbols!";
        private const string AgeErrorMsg = "Age cannot be zero or a negative integer!";
        private const string SalaryErrorMsg = "Salary cannot be less than 650 leva!";

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
            get { return firstName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(FirstNameErrorMsg);
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException(LastNameErrorMsg);
                }

                lastName = value;
            }
        }

        public int Age
        {
            get { return age; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(AgeErrorMsg);
                }

                age = value;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            private set
            {
                if (salary < 650)
                {
                    throw new ArgumentException(SalaryErrorMsg);
                }

                salary = value;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}
