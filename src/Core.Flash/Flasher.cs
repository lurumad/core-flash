using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Core.Flash.Model;
using Core.Flash.Extensions;

namespace Core.Flash
{
    public class Flasher : IFlasher
    {
        private readonly ITempDataDictionaryFactory tempDataDictionaryFactory;
        private readonly IHttpContextAccessor httpContextAccessor;

        public Flasher(ITempDataDictionaryFactory factory, IHttpContextAccessor httpContextAccessor)
        {
            this.tempDataDictionaryFactory = factory;
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Flash(string type, string message, bool dismissable = false)
        {
            var tempData = GetTempData();
            var messages = tempData.Get<Queue<Message>>(Constants.Key) ?? new Queue<Message>();
            messages.Enqueue(new Message(type, message, dismissable));
            tempData.Put(Constants.Key, messages);
            tempData.Save();
        }

        public bool Any()
        {
            return GetTempData().ContainsKey(Constants.Key);
        }

        private ITempDataDictionary GetTempData()
        {
            return tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
        }
    }
}
