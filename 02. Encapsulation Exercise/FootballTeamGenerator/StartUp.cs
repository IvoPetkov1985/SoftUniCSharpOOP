using FootballTeamGenerator;

List<Team> teams = new();

string inputLine = Console.ReadLine();

while (inputLine != "END")
{
    string[] tokens = inputLine.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string command = tokens[0];

    try
    {
        switch (command)
        {
            case "Team":
                string teamName = tokens[1];
                AddTeam(teamName, teams);
                break;
            case "Add":
                string teamInputName = tokens[1];
                string playerName = tokens[2];
                int endurance = int.Parse(tokens[3]);
                int sprint = int.Parse(tokens[4]);
                int dribble = int.Parse(tokens[5]);
                int passing = int.Parse(tokens[6]);
                int shooting = int.Parse(tokens[7]);
                AddPlayer(teamInputName, playerName, endurance, sprint, dribble, passing, shooting, teams);
                break;
            case "Remove":
                string teamNameToRemoveFrom = tokens[1];
                string playerNameToRemove = tokens[2];
                RemovePlayer(teamNameToRemoveFrom, playerNameToRemove, teams);
                break;
            case "Rating":
                string nameOfTeam = tokens[1];
                PrintTeamRating(nameOfTeam, teams);
                break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }

    inputLine = Console.ReadLine();
}

static void AddTeam(string teamName, List<Team> teams)
{
    teams.Add(new Team(teamName));
}

static void AddPlayer(string teamName,
    string playerName,
    int endurance,
    int sprint,
    int dribble,
    int passing,
    int shooting,
    List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team == null)
    {
        throw new ArgumentException($"Team {teamName} does not exist.");
    }

    Player player = new(playerName, endurance, sprint, dribble, passing, shooting);
    team.AddPlayer(player);
}

static void RemovePlayer(string teamName, string playerName, List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team == null)
    {
        throw new ArgumentException($"Team {teamName} does not exist.");
    }

    team.RemovePlayer(playerName);
}

static void PrintTeamRating(string teamName, List<Team> teams)
{
    Team team = teams.FirstOrDefault(t => t.Name == teamName);

    if (team == null)
    {
        throw new ArgumentException($"Team {teamName} does not exist.");
    }

    Console.WriteLine($"{team.Name} - {team.Rating:F0}");
}
