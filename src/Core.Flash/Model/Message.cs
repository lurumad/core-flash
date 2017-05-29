namespace Core.Flash.Model
{
    public class Message
    {
        public string Type { get; }
        public string Text { get; }

        public Message(string type, string text)
        {
            Type = type;
            Text = text;
        }
    }
}
