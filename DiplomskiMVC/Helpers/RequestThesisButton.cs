using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Helpers
{
    [HtmlTargetElement("RequestThesisButton", Attributes = "user-id")]
    public class RequestThesisButton : TagHelper
    {
        private readonly IRequestService _requestService;
        public RequestThesisButton(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            bool userCheck = _requestService.CanStudentRequest(context.AllAttributes["user-id"].Value.ToString()).Result;
            output.TagName = "button";
            if (!userCheck)
                output.Attributes.Add("disabled", "true");

        }
    }
}
