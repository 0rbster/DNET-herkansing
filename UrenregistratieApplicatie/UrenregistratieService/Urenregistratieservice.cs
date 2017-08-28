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
            using (DBmodelContainer ctx = new DBmodelContainer())
            {
                var gebruiker = ctx.UserSet.SingleOrDefault(g => g.Gebruikersnaam.Equals(gebruikersnaam) && g.Wachtwoord.Equals(wachtwoord));
                if (gebruiker.Equals(null))
                {
                    return false;
                } else
                {
                    return true;
                }
            }
        }
    }
}
