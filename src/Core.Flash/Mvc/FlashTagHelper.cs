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
        private readonly ITempDataDictionaryFactory tempDataDictionaryFactory;
        private readonly IHttpContextAccessor httpContextAccessor;

        private const string HtmlStandardTemplate = "<div class=\"alert alert-{0} fade show\">{1}</div>";

        private const string HtmlDismissableTemplate =
            "<div class=\"alert alert-{0} alert-dismissible fade show\" role=\"alert\">" +
                @"<button type=""button"" class=""btn-close"" data-bs-dismiss=""alert"" aria-label=""Close""></button>{1}" + 
            "</div>";

        public FlashesTagHelper(ITempDataDictionaryFactory factory, IHttpContextAccessor httpContextAccessor)
        {
            this.tempDataDictionaryFactory = factory;
            this.httpContextAccessor = httpContextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tempData = GetTempData();
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

        private ITempDataDictionary GetTempData()
        {
            return tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
        }
    }
}
