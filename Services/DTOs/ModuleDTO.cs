using System;
using System.Collections.Generic;
using Data.Entityes;
using System.Text;
using System.Linq;

namespace Services.DTOs
{
    public class ModuleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SubjectDTO> SubjectDTOList { get; set; }

        public Module ToModule()
        {
            return new Module
            {
                Id = Id,
                Name = Name
            };
        }

        public static implicit operator ModuleDTO(Module module)
        {
            if (module == null)
                return null;
            return new ModuleDTO
            {
                Id = module.Id,
                Name = module.Name,
                SubjectDTOList = module.SubjectsList == null ? null : module.SubjectsList.Select(e => (SubjectDTO)e)
            };
        }

        public static ModuleDTO CastWithoutLists(Module module)
        {
            if (module == null)
                return null;
            return new ModuleDTO
            {
                Id = module.Id,
                Name = module.Name
            };
        }
    }
}
