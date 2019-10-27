using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

using Core.Flash.Model;
using Core.Flash.Extensions;

namespace Core.Flash.Mvc
{
    [HtmlTargetElement("div", Attributes = "flashes")]
    public class FlashesTagHelper : TagHelper
    {
        private readonly ITempDataDictionary tempData;

        private const string HtmlStandardTemplate = "<div class=\"alert alert-{0}\">{1}</div>";

        private const string HtmlDismissableTemplate = 
            "<div class=\"alert alert-{0} alert-dismissible\" role=\"alert\">" +
                "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                    "<span aria-hidden=\"true\">&times;</span>" +
                "</button>{1}" +
            "</div>";

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

                var html = message.Dismissable
                    ? string.Format(HtmlDismissableTemplate, message.Type, message.Text)
                    : string.Format(HtmlStandardTemplate, message.Type, message.Text);

                output.Content.AppendHtml(html);
            }
        }
    }
}
