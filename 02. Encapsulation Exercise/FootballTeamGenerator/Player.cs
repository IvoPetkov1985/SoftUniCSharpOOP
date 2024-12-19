namespace FootballTeamGenerator
{
    public class Player
    {
        private const string SkillErrorMessage = "{0} should be between 0 and 100.";
        private const string NameErrorMessage = "A name should not be empty.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(NameErrorMessage);
                }

                name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(SkillErrorMessage, nameof(Endurance)));
                }

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(SkillErrorMessage, nameof(Sprint)));
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(SkillErrorMessage, nameof(Dribble)));
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(SkillErrorMessage, nameof(Passing)));
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(SkillErrorMessage, nameof(Shooting)));
                }

                shooting = value;
            }
        }

        public double Stats => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
    }
}
