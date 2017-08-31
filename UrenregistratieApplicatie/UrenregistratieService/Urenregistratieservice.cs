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
        //Controleert of de gebruikersnaam en wachtwoord voorkomen in de database
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

        //Slaat de nieuwe gebruiker op in de database als de opgegeven gebruikersnaam nog niet voorkomt in de database
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

        //Haalt een lijst met taken op van het huidige project van de gebruiker
        public List<string> TakenOphalen(string gebruikersnaam)
        {
            using (UrenregistratieDBEntities ctx = new UrenregistratieDBEntities())
            {
                UserSet gebruiker = GebruikerOphalen(gebruikersnaam);
                int gebruikerid = gebruiker.UserId;
                var taken = from t in ctx.TaakSet
                            where t.UserUserId == gebruikerid
                            select t;
                var takenlijst = new List<string>();
                foreach (var t in taken)
                {
                    takenlijst.Add(t.Type);
                }

                return takenlijst;
            }
        }

        // haalt de gewerkte uren op van 1 taak van de gebruiker z'n huidige project
        public int GewerkteUrenOphalen(string taak, string gebruikersnaam)
        {
            using (UrenregistratieDBEntities ctx = new UrenregistratieDBEntities())
            {
                UserSet gebruiker = GebruikerOphalen(gebruikersnaam);
                int projectID = Convert.ToInt32(gebruiker.ProjectProjectId);
                TaakSet task = ctx.TaakSet.SingleOrDefault(t => t.Type.Equals(taak) && t.UserUserId.Equals(gebruiker.UserId) && t.ProjectProjectId.Equals(projectID));
                return task.Uren;
                
            }
        }

        // haalt een gebruiker op uit de database
        public UserSet GebruikerOphalen(string gebruikersnaam)
        {
            using (UrenregistratieDBEntities ctx = new UrenregistratieDBEntities())
            {
                UserSet gebruiker = ctx.UserSet.Single(g => g.Gebruikersnaam.Equals(gebruikersnaam));
                return gebruiker;
            }
        }
        
        // slaat het aantal gewerkte uren op in de TaakSet tabel
        public void UrenOpslaan(string taak, int uren, string gebruikersnaam)
        {
            using (UrenregistratieDBEntities ctx = new UrenregistratieDBEntities())
            {
                UserSet gebruiker = GebruikerOphalen(gebruikersnaam);
                int projectID = Convert.ToInt32(gebruiker.ProjectProjectId);
                TaakSet task = ctx.TaakSet.SingleOrDefault(t => t.Type.Equals(taak) && t.UserUserId.Equals(gebruiker.UserId) && t.ProjectProjectId.Equals(projectID));
                task.Uren = uren;
                ctx.SaveChanges();
            }
        }
    }
}
