using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Core.Flash.Model;
using Core.Flash.Extensions;

namespace Core.Flash
{
    public class Flasher : IFlasher
    {
        private readonly ITempDataDictionary tempData;

        public Flasher(ITempDataDictionaryFactory factory, IHttpContextAccessor httpContextAccessor)
        {
            tempData = factory.GetTempData(httpContextAccessor.HttpContext);
        }

        public void Flash(string type, string message, bool dismissable = false)
        {
            var messages = tempData.Get<Queue<Message>>(Constants.Key) ?? new Queue<Message>();
            messages.Enqueue(new Message(type, message, dismissable));
            tempData.Put(Constants.Key, messages);
            tempData.Save();
        }

        public bool Any()
        {
            return tempData.ContainsKey(Constants.Key);
        }
    }
}
