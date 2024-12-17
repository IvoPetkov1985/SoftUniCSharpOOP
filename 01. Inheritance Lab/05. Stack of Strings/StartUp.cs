namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new();

            stack.AddRange(new List<string>() { "12", "14", "128" });

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
