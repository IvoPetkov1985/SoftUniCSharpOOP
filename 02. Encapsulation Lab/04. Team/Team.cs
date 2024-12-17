using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam { get { return firstTeam.AsReadOnly(); } }

        public IReadOnlyCollection<Person> ReserveTeam { get { return reserveTeam.AsReadOnly(); } }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                firstTeam.Add(player);
            }
            else
            {
                reserveTeam.Add(player);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            builder.AppendLine($"First team has {FirstTeam.Count} players.");
            builder.AppendLine($"Reserve team has {ReserveTeam.Count} players.");

            return builder.ToString().TrimEnd();
        }
    }
}
