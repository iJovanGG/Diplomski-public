using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Helpers
{
    [HtmlTargetElement("ProfessorUnhandledRequests", Attributes = "professor-id")]
    public class ProfessorUnhandledRequests : TagHelper
    {
        private readonly IRequestService _requestService;
        public ProfessorUnhandledRequests(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int unhandledRequests = _requestService.NumberOfUnhandledRequests(context.AllAttributes["professor-id"].Value.ToString()).Result;
            output.TagName = "span";
            if (unhandledRequests == 0)
                output.Attributes.Add("style", "display:none;");
            output.Content.Append(unhandledRequests.ToString());
        }
    }
}
