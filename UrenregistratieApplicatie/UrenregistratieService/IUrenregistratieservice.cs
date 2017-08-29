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
    }
}
