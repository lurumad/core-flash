using System.Collections.Generic;
using System.Linq;
using Core.Flash.Model;

namespace Core.Flash.Implementations
{
    public class BulmaMessageRenderer : IMessageRenderer
    {
        public string RenderMessages(IEnumerable<Message> messages) =>
            $"<section class=\"section\"><div class=\"container\">{string.Join("\n", messages.Select(RenderMessage))}</div></section>";

        // Dismissible notifications requires custom JavaScript (Bulma does not ship any JS)
        private static string RenderMessage(Message message) =>
            $"<div class=\"notification is-{message.Type}\">{message.Text}</div>";
    }
}