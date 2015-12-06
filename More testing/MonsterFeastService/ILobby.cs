using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonsterFeastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "MonsterFeastService", CallbackContract = typeof(ILobbyCallback))]
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
        //[OperationContract]
        //void ChooseNation(Element el);
        //[OperationContract]
        //void ChooseClass(CharClass c);
        //[OperationContract]
        //Session[] getSession();


        // ILobby
        // For lobby purposes.
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

        // IChat
        // For chatting between players.
        [OperationContract]
        void SendMessage(string message, Player sender, DateTime time);
        [OperationContract]
        void SubscribeChatBox();
        [OperationContract]
        void UnSubscribeChatBox();
    }
    interface ILobbyCallback
    {
        [OperationContract(IsOneWay = true)]
        void updateChatBox(string message);
    }

    
}
