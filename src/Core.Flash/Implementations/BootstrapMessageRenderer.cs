using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Flash.Model;

namespace Core.Flash.Implementations
{
    public class BootstrapMessageRenderer : IMessageRenderer
    {
        public string RenderMessages(IEnumerable<Message> messages) =>
            string.Join("\n", messages.Select(RenderMessage));

        private string RenderMessage(Message message) =>
            message.Dismissable
                ? $"<div class=\"alert alert-{message.Type} alert-dismissible\">" +
                  "<button type=\"button\" class=\"close\" data-close=\"alert\"><span aria-hidden=\"true\">&times;</span></button>" +
                  $"{HttpUtility.HtmlEncode(message.Text)}</div>"
                : $"<div class=\'alert alert-{message.Type}\">{message.Text}</div>";
    }
}