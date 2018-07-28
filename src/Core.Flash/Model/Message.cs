namespace Core.Flash.Model
{
    public class Message
    {
        public string Type { get; }
        public string Text { get; }
        public bool Dismissable { get; }

        public Message(string type, string text, bool dismissable)
        {
            Type = type;
            Text = text;
            Dismissable = dismissable;
        }
    }
}
