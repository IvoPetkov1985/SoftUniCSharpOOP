﻿ICollection<Card> cards = new List<Card>();

string inputLine = Console.ReadLine();
string[] inputTokens = inputLine.Split(", ", StringSplitOptions.RemoveEmptyEntries);

foreach (string inputToken in inputTokens)
{
    string[] cardTokens = inputToken.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string face = cardTokens[0];
    string suit = cardTokens[1];

    try
    {
        Card card = new(face, suit);
        cards.Add(card);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(" ", cards));

public class Card
{
    private string face;
    private string suit;

    private readonly IReadOnlyCollection<string> faces;
    private readonly IReadOnlyDictionary<string, string> suits;

    public Card(string face, string suit)
    {
        this.faces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        this.suits = new Dictionary<string, string>
        {
            ["S"] = "\u2660",
            ["H"] = "\u2665",
            ["D"] = "\u2666",
            ["C"] = "\u2663"
        };

        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get { return face; }
        private set
        {
            if (!faces.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }

            face = value;
        }
    }


    public string Suit
    {
        get { return suits[suit]; }
        private set
        {
            if (!suits.ContainsKey(value))
            {
                throw new ArgumentException("Invalid card!");
            }

            suit = value;
        }
    }

    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }
}
