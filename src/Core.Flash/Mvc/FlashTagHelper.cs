using Core.Flash.Extensions;
using Core.Flash.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Core.Flash.Mvc
{
    [HtmlTargetElement("div", Attributes = "flashes")]
    public class FlashesTagHelper : TagHelper
    {
        private ITempDataDictionary tempData;

        public FlashesTagHelper(ITempDataDictionaryFactory factory, IHttpContextAccessor contextAccessor)
        {
            tempData = factory.GetTempData(contextAccessor.HttpContext);
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var messages = tempData.Get<Queue<Message>>(Constants.Key) ?? new Queue<Message>();

            while (messages.Count > 0)
            {
                var message = messages.Dequeue();
                var html = $@"<div class=""alert alert-{message.Type}"">{message.Text}</div>";
                output.Content.AppendHtml(html);
            }
        }
    }
}
