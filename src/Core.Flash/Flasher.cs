using Core.Flash.Abstractions;
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

        public void FlashPrimary(string message, bool dismissable = false)
        {
            Flash(Types.Primary, message, dismissable);	
        }

        public void FlashSecondary(string message, bool dismissable = false)
        {
            Flash(Types.Secondary, message, dismissable);	
        }

        public void FlashSuccess(string message, bool dismissable = false)
        {
            Flash(Types.Success, message, dismissable);	
        }

        public void FlashDanger(string message, bool dismissable = false)
        {
            Flash(Types.Danger, message, dismissable);	
        }

        public void FlashWarning(string message, bool dismissable = false)
        {
            Flash(Types.Warning, message, dismissable);	
        }

        public void FlashInfo(string message, bool dismissable = false)
        {
            Flash(Types.Info, message, dismissable);	
        }

        public void FlashLight(string message, bool dismissable = false)
        {
            Flash(Types.Light, message, dismissable);	
        }

        public void FlashDark(string message, bool dismissable = false)
        {
            Flash(Types.Dark, message, dismissable);	
        }
	
        public bool Any()
        {
            return tempData.ContainsKey(Constants.Key);
        }
    }
}
