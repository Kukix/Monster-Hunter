using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonsterFeastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CGame : IGame, ILobby
    {
        private bool isStart;
        private bool isEnd;
        List<string> onlinePlayers;
        DataHelper dh = new DataHelper();
        Player player;
        public CGame() { }
        private Action<string> MyMessage = delegate { };

        public int calculateDamage(Player attacker, Player defender) { return 0; }

        public int calculateHP(Player defender, int damage) { return 0; }

        public int calculateExp(Player p) { return 0; }

        public void changeTurn() { }

        public void attack(Skill a) { }

        public void usePoint() { }

        public void giveUp() { }

        public void sendMessage(string message, Player sender, DateTime time) { }


        public void Register(string username, string password)
        {
            dh.Register(username, password);
        }

        public Player Login(string username, string password)
        {
            player = dh.GetPlayer(username, password);
            return player;
        }

        public bool Logout()
        {
            throw new NotImplementedException();
        }

        public bool isFirstTime()
        {
            throw new NotImplementedException();
        }

        public void FindMatch()
        {
            throw new NotImplementedException();
        }

        public void AllocateAttribute(Attribute a)
        {
            throw new NotImplementedException();
        }

        public void SubscribeMatch(int roomNr)
        {
            throw new NotImplementedException();
        }

        public void UnSubscribeMatch(int roomNr)
        {
            throw new NotImplementedException();
        }

        public void SubscribeListPlayers()
        {
            throw new NotImplementedException();
        }

        public void UnSubscribeListPlayers()
        {
            throw new NotImplementedException();
        }

        public List<string> getOnlinePlayers()
        {
            onlinePlayers = dh.getOnlinePlayers();
            return onlinePlayers;
        }

        public void SendMessage(string message, Player sender, DateTime time)
        {
            throw new NotImplementedException();
        }

        public void SubscribeChatBox()
        {
            ILobbyCallback clientCallback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
            MyMessage -= clientCallback.updateChatBox;
            MyMessage += clientCallback.updateChatBox;
        }

        public void UnSubscribeChatBox()
        {
            ILobbyCallback clientCallback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
            MyMessage -= clientCallback.updateChatBox;
        }
    }
}
