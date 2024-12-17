namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList customList = new();
            customList.Add("1");
            customList.Add("3");
            customList.Add("41");
            customList.Add("161");
            customList.Add("333");

            Console.WriteLine(customList.RandomString());
            Console.WriteLine(customList.RandomString());
            Console.WriteLine(customList.RandomString());
            Console.WriteLine(customList.RandomString());
            Console.WriteLine(customList.RandomString());
        }
    }
}
