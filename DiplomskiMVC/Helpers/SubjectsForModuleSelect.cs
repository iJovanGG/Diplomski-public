using DiplomskiMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Helpers
{
    [HtmlTargetElement("SubjectsForModuleSelect", Attributes = "selected-id, module-id")]
    public class SubjectsForModuleSelect : TagHelper
    {
        private static IModuleService _moduleService;

        public SubjectsForModuleSelect(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int.TryParse(context.AllAttributes["module-id"].Value.ToString(), out int moduleId);
            string selectedIds = context.AllAttributes["selected-id"] == null ? null : context.AllAttributes["selected-id"].Value.ToString();

            IEnumerable<SubjectView> subjects = _moduleService
                .GetSubjectsForModule(moduleId).Result.Select(e => (SubjectView)e);

            List<int> selectedIdsList = (selectedIds == "" || selectedIds == null) ? null
                : selectedIds.Split(",").Select(int.Parse).ToList();

            output.TagName = "select";

            foreach (SubjectView s in subjects)
            {
                TagBuilder option = new TagBuilder("option");
                option.InnerHtml.Append(s.Name);
                option.Attributes.Add("value", s.Id.ToString());
                if (selectedIdsList != null && selectedIdsList.Contains(s.Id))
                    option.Attributes.Add("selected", "");
                output.Content.AppendHtml(option);
            }

        }
    }
}
