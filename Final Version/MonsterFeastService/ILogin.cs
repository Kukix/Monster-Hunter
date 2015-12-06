using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MonsterFeastService
{
    [ServiceContract(Namespace = "MonsterFeastService")]
    interface ILogin
    {
        [OperationContract]
        bool isRegistered(string username);
        [OperationContract]
        void Register(string username, string password);
        [OperationContract]
        Player Login(string username, string password);
        
        [OperationContract]
        bool hasChar(string username);
        [OperationContract]
        void createCharacter(int id, string name, CharClass charClass, Element element);
        [OperationContract]
        void addToList(Player p);
    }
}
