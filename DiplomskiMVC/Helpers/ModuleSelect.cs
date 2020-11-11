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
    [HtmlTargetElement("SubjectModule", Attributes = "selected-id")]
    public class ModuleSelect : TagHelper
    {
        private static IModuleService _moduleService;
        public ModuleSelect(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IEnumerable<ModuleView> modules = _moduleService.GetAllModuleDTOs(false).Result.Select(e => (ModuleView)e);

            int.TryParse(context.AllAttributes["selected-id"].Value.ToString(), out int selectedId);

            output.TagName = "select";

            foreach (ModuleView m in modules)
            {
                TagBuilder option = new TagBuilder("option");
                option.InnerHtml.Append(m.Name);
                option.Attributes.Add("value", m.Id.ToString());
                if (selectedId == m.Id)
                    option.Attributes.Add("selected", "");
                output.Content.AppendHtml(option);
            }

        }
    }
}
