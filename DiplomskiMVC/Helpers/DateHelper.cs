using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Helpers
{
    public static class DateHelper
    {
        public static string PrettyDifference(DateTime date, DateTime subtractDate)
        {
            int hours = (int)(date - subtractDate).TotalHours;
            if(hours < 1)
            {
                return "pre manje od sat";
            }
            else if(hours < 24)
            {
                return "pre " + hours + " sata";
            }
            else if(hours < 24 * 7)
            {
                return "pre " + hours/24 + " dana";
            }
            else if (hours < 24 * 7 * 4)
            {
                return "pre " + hours / (24 * 7) + " nedelja";
            }
            else
            {
                return "pre " + hours / (24 * 7 * 4) + " meseca";
            }
        }
    }
}
