using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MonsterFeastService
{
    [ServiceContract(Namespace = "MonsterFeastContract", CallbackContract = typeof(ILobbyCallback))]
    public interface ILobby
    {
        // ILogin
        // For login and register purposes.
        [OperationContract]
        void Register(string username, string password);
        [OperationContract]
        Player Login(string username, string password);
        [OperationContract]
        bool Logout();
        [OperationContract]
        bool isFirstTime();

        [OperationContract]
        void FindMatch();
        [OperationContract]
        void AllocateAttribute(Attribute a);
        [OperationContract]
        void SubscribeMatch(int roomNr);
        [OperationContract]
        void UnSubscribeMatch(int roomNr);
        [OperationContract]
        void SubscribeListPlayers();
        [OperationContract]
        void UnSubscribeListPlayers();
        [OperationContract]
        List<string> getOnlinePlayers();

        [OperationContract]
        void SendMessage(string message, Player sender, DateTime time);
        [OperationContract]
        void SubscribeChatBox();
        [OperationContract]
        void UnSubscribeChatBox();
    }

    public interface ILobbyCallback
    {
        [OperationContract(IsOneWay = true)]
        void updateChatBox(string message);
    }
}
