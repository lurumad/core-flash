using System.Collections.Generic;
using Core.Flash.Model;

namespace Core.Flash
{
    public interface IMessageRenderer
    {
        public string RenderMessages(IEnumerable<Message> messages);
    }
}