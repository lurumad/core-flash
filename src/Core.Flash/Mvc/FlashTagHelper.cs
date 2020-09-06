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
        private readonly IMessageRenderer messageRenderer;

        private const string HtmlStandardTemplate = "<div class=\"alert alert-{0}\">{1}</div>";

        private const string HtmlDismissableTemplate = 
            "<div class=\"alert alert-{0} alert-dismissible\" role=\"alert\">" +
                "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                    "<span aria-hidden=\"true\">&times;</span>" +
                "</button>{1}" +
            "</div>";

        public FlashesTagHelper(ITempDataDictionaryFactory factory, IHttpContextAccessor httpContextAccessor, IMessageRenderer messageRenderer)
        {
            this.tempDataDictionaryFactory = factory;
            this.httpContextAccessor = httpContextAccessor;
            this.messageRenderer = messageRenderer;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tempData = GetTempData();
            var messages = tempData.Get<Queue<Message>>(Constants.Key) ?? new Queue<Message>();

            if (messages.Count > 0)
            {
                output.Content.AppendHtml(messageRenderer.RenderMessages(messages));
                messages.Clear();
            }
            tempData.Put(Constants.Key, messages);
        }

        private ITempDataDictionary GetTempData()
        {
            return tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
        }
    }
}
