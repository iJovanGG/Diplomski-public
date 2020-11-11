using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiMVC.Helpers
{
    public class Translator
    {
        public static string Translate(RequestStatus status)
        {
            switch (status)
            {
                case RequestStatus.Accepted:
                    return "Prihvaćen";
                case RequestStatus.Denied:
                    return "Odbijen";
                case RequestStatus.Canceled:
                    return "Otkazan od strane korisnika";
                case RequestStatus.Pending:
                    return "U obradi";
                case RequestStatus.TakenBySomeoneElse:
                    return "Dodeljen drugom korisniku";
            }
            return status.ToString("g");
        }
    }
}
