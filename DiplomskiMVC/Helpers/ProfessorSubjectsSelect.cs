using DiplomskiMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.DTOs;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DiplomskiMVC.Helpers
{
    [HtmlTargetElement("SubjectsSelect", Attributes = "selected-id, user-id")]
    public class ProfessorSubjectsSelect : TagHelper
    {
        private static ISubjectService _subjectService;
        public ProfessorSubjectsSelect( ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IEnumerable<SubjectView> subjects = _subjectService
                .GetSubjectsByProfessorId(context.AllAttributes["user-id"].Value.ToString()).Result.Select(e => (SubjectView)e);

            int.TryParse(context.AllAttributes["selected-id"].Value.ToString(), out int selectedId);

            output.TagName = "select";

            foreach(SubjectView s in subjects)
            {
                TagBuilder option = new TagBuilder("option");
                option.InnerHtml.Append(s.Name);
                option.Attributes.Add("value", s.Id.ToString());
                if (selectedId == s.Id)
                    option.Attributes.Add("selected", "");
                output.Content.AppendHtml(option);
            }

        }
    }
}
