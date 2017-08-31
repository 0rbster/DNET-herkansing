using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UrenregistratieService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUrenregistratieservice" in both code and config file together.
    [ServiceContract]
    public interface IUrenregistratieservice
    {
        [OperationContract]
        bool Login(string gebruikersnaam, string wachtwoord);

        [OperationContract]
        bool Registreer(string gebruikersnaam);

        [OperationContract]
        List<string> TakenOphalen(string gebruikersnaam, string wachtwoord);

        [OperationContract]
        int GewerkteUrenOphalen(string taak, string gebruikersnaam, string wachtwoord);

        [OperationContract]
        UserSet GebruikerOphalen(string gebruikersnaam);

        [OperationContract]
        bool UrenOpslaan(string taak, int uren, string gebruikersnaam, string wachtwoord);

        [OperationContract]
        bool TaakVerwijderen(string taak, string gebruikersnaam, string wachtwoord);

        [OperationContract]
        TaakSet TaakOphalen(string taak, string gebruikersnaam);
    }
}
