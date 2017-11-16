using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace SecureClient
{
    [ServiceContract]
    interface IContract
    {
        [OperationContract]
        void Say(string input);

        [OperationContract]
        void SendMessage(string input);

        [OperationContract]
        bool Registration(string login, string password);

        [OperationContract]
        bool Autentification(string login, string password);



    }
}
