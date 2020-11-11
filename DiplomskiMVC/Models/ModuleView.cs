using Services.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class ModuleView
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<SubjectView> SubjectDTOList { get; set; }

        public static implicit operator ModuleView(ModuleDTO moduleDTO)
        {
            if (moduleDTO == null)
                return null;
            return new ModuleView
            {
                Id = moduleDTO.Id,
                Name = moduleDTO.Name,
                SubjectDTOList = moduleDTO.SubjectDTOList == null ? null : moduleDTO.SubjectDTOList.Select(e => (SubjectView)e)
            };
        }

        public static ModuleView CastWithoutList(ModuleDTO moduleDTO)
        {
            if (moduleDTO == null)
                return null;
            return new ModuleView
            {
                Id = moduleDTO.Id,
                Name = moduleDTO.Name
            };
        }

        public ModuleDTO ToModuleDTO()
        {
            return new ModuleDTO
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
