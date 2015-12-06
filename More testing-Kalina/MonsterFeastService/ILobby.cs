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
        void SubscribeLobby();
        [OperationContract]
        void UnSubscribeLobby();
        [OperationContract]
        List<string> getOnlinePlayers();
        [OperationContract]
        Player getPlayer(string username);
        [OperationContract]
        List<Player> getPlayers();
        [OperationContract]
        Character getCharacter(int id);
        [OperationContract]
        void sendChallenge(string challenger, string reciever);
        [OperationContract]
        void answerChallenge(Player challenger, Player reciever, bool answer);
        [OperationContract]
        void updateAttributes(string name, int strength, int constitution, int magic, int wisdom, int dexterity, int agility, int attributePoints);
        [OperationContract]
        void createRoom(Player player, int rmNumber);
        [OperationContract]
        void joinRoom(Player player, int rmNumber);


        // IChat
        // For chatting between players.
        [OperationContract]
        void SendMessage(string message,DateTime date);
        [OperationContract]
        string GetChatMessage();
    }

    interface ILobbyCallback
    {
        //Update inofmation in lobby
        [OperationContract(IsOneWay = true)]
        void updateChatBox(string message);

        [OperationContract(IsOneWay = true)]
        void updatePlayerList(List<Player> players);

        [OperationContract(IsOneWay = true)]
        void updateMatchList(List<Match> matches);

        //Challenge another opponent callbacks
        [OperationContract(IsOneWay = true)]
        void ChallengeSent(string player1, string player2);

        [OperationContract(IsOneWay = true)]
        void ChallengeDenied(string player);

        [OperationContract(IsOneWay = true)]
        void ChallengeAccepted(string player, Match match);

        [OperationContract(IsOneWay = true)]
        void GameCreated(Player player1, Player player2, Match match, Player currentPlayer);
    }  
}
