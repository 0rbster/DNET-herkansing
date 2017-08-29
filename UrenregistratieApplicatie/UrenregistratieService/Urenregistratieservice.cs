using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UrenregistratieService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Urenregistratieservice" in both code and config file together.
    public class Urenregistratieservice : IUrenregistratieservice
    {
        public bool Login(string gebruikersnaam, string wachtwoord)
        {
            using (UrenregistratieDBEntities ctx = new UrenregistratieDBEntities())
            {
                var gebruiker = ctx.UserSet.SingleOrDefault(g => g.Gebruikersnaam.Equals(gebruikersnaam) && g.Wachtwoord.Equals(wachtwoord));
                if (gebruiker == null)
                {
                    return false;
                } else
                {
                    return true;
                }
            }
        }

        public bool Registreer(string gebruikersnaam)
        {
            var charArray = gebruikersnaam.ToCharArray();
            Array.Reverse(charArray);
            var ww = new string(charArray);
            var gebruiker = new UserSet()
            {
                Wachtwoord = ww,
                Gebruikersnaam = gebruikersnaam,
                ProjectProjectId = 1,
            };

            var taken = new List<TaakSet>(5)
            {
                new TaakSet() { Uren = 0, Type = "Programmeren", UserUserId = gebruiker.UserId, ProjectProjectId = 1 },
                new TaakSet() { Uren = 0, Type = "Ontwerpen", UserUserId = gebruiker.UserId, ProjectProjectId = 1 },
                new TaakSet() { Uren = 0, Type = "Adviseren", UserUserId = gebruiker.UserId, ProjectProjectId = 1 },
                new TaakSet() { Uren = 0, Type = "Deskundigheid", UserUserId = gebruiker.UserId, ProjectProjectId = 1 },
                new TaakSet() { Uren = 0, Type = "Overig", UserUserId = gebruiker.UserId, ProjectProjectId = 1 }
            }; 

            using (UrenregistratieDBEntities ctx = new UrenregistratieDBEntities())
            {
                var gebruikerN = ctx.UserSet.SingleOrDefault(g => g.Gebruikersnaam.Equals(gebruikersnaam));
                if (gebruikerN == null)
                {
                    ctx.TaakSet.AddRange(taken);
                    ctx.UserSet.Add(gebruiker);
                    ctx.SaveChanges();
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
