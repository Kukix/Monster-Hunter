using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonsterFeastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "MonsterFeastService")]
    interface ILogin
    {
        // ILogin
        // For login and register purposes.
        [OperationContract]
        bool isRegistered(string username);
        [OperationContract]
        void Register(string username, string password);
        [OperationContract]
        Player Login(string username, string password);
        [OperationContract]
        void Logout(Player player);
        [OperationContract]
        bool hasChar(string username);
        [OperationContract]
        void createCharacter(int id, string name, CharClass charClass, Element element);
        [OperationContract]
        void addToList(Player p);
    }
}
