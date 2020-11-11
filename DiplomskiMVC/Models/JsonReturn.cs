using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Models
{
    public class JsonReturn
    {
        public string Status { get; set; }
        public List<string> ErrorMessage { get; set; }
        public Object Object {get; set;}
    }
}
