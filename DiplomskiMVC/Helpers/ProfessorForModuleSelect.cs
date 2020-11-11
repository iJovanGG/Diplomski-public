using Amazon.S3.Model;
using DiplomskiMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Helpers
{
    [HtmlTargetElement("ProfessorForModuleSelect", Attributes = "selected-id, module-id")]
    public class ProfessorForModuleSelect : TagHelper
    {
        private static IModuleService _moduleService;

        public ProfessorForModuleSelect(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string selectedIds = context.AllAttributes["selected-id"] == null ? null : context.AllAttributes["selected-id"].Value.ToString();
            int.TryParse(context.AllAttributes["module-id"].Value.ToString(), out int moduleId);

            List<string> selectedIdsList = (selectedIds == "" || selectedIds == null) ? null 
                : selectedIds.Split(",").ToList();

            IEnumerable<FacultyProfessorView> subjects = _moduleService
                .GetProfessorsForModule(moduleId).Result.Select(e => (FacultyProfessorView)e);

            output.TagName = "select";

            foreach (FacultyProfessorView p in subjects)
            {
                TagBuilder option = new TagBuilder("option");
                option.InnerHtml.Append(p.FullName);
                option.Attributes.Add("value", p.Id);
                if (selectedIdsList != null && selectedIdsList.Contains(p.Id))
                    option.Attributes.Add("selected", "");
                output.Content.AppendHtml(option);
            }

        }
    }
}
