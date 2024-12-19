namespace FootballTeamGenerator
{
    public class Team
    {
        private const string NameErrorMessage = "A name should not be empty.";
        private const string MissingPlayerErrorMessage = "Player {0} is not in {1} team.";

        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
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

        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(p => p.Stats);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (players.Any(p => p.Name == playerName))
            {
                Player player = players.First(p => p.Name == playerName);

                players.Remove(player);
            }
            else
            {
                throw new ArgumentException(string.Format(MissingPlayerErrorMessage, playerName, Name));
            }
        }
    }
}
