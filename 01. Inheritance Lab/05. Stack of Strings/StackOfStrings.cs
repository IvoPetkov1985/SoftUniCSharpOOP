namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> values)
        {
            foreach (string value in values)
            {
                this.Push(value);
            }
        }
    }
}
