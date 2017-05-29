using Core.Flash.Extensions;
using Core.Flash.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace Core.Flash
{
    public class Flasher : IFlasher
    {
        private ITempDataDictionary tempData;

        public Flasher(ITempDataDictionaryFactory factory, IHttpContextAccessor contextAccessor)
        {
            tempData = factory.GetTempData(contextAccessor.HttpContext);
        }

        public void Flash(string type, string message)
        {
            var messages = tempData.Get<Queue<Message>>(Constants.Key) ?? new Queue<Message>();
            messages.Enqueue(new Message(type, message));
            tempData.Put(Constants.Key, messages);
        }
    }
}
