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
    public class CGame : IGame,ILobby,ILogin
    {
        private bool isStart;
        private bool isEnd;
        List<string> onlinePlayers;
        private List<string> lobbyChat;
        DataHelper dh = new DataHelper();
        private List<Player> players;
        private List<Match> matches;

        //private Action<Player,string> MyMessage = delegate { };
        private Action<List<Player>> MyPlayerList = delegate { };
        private Action<List<Match>> MyMatchList = delegate { };
        //static Action messageLobby = delegate { };
        private Action<string> MyMessageSent = delegate { };
        private Action<string, string> sentChallenge = delegate { };
        private Action<string, Match> acceptedChallenge = delegate { };
        private Action<string> deniedChallenge = delegate { };

        public CGame() 
        {
            players = new List<Player>();
            lobbyChat = new List<string>();
            matches = new List<Match>();
        }

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

        public bool isRegistered(string username) 
        {
            return dh.isRegistered(username);
        }

        public Player Login(string username, string password)
        {
            Player player1 = new Player();
            player1 = dh.GetPlayer(username, password);
            //MyPlayerList(players);
            return player1;
        }

        public void addToList(Player p) 
        {
            players.Add(p);
            MyPlayerList(players);
        }

        public bool hasChar(string username) 
        {
            return dh.hasCharacter(username);
        }

        public void createCharacter(int id,string name, CharClass charClass, Element element) 
        {
            dh.createCharacter(id,name,charClass,element);
        }

        public Player getPlayer(string username) 
        {
            return dh.getOpponent(username);
        }

        public Character getCharacter(int id) 
        {
            Character playerCharacter = new Character();
            playerCharacter = dh.GetCharacter(id);
            return playerCharacter;
        }

        public void updateAttributes(string name, int strength, int constitution, int magic, int wisdom, int dexterity, int agility, int attributePoints) 
        {
            dh.updateAttributes(name, strength, constitution, magic, wisdom, dexterity, agility, attributePoints);
        }

        public void Logout(Player player)
        {
            players.Remove(player);
            MyPlayerList(players);
        }

        public void FindMatch()
        {
            throw new NotImplementedException();
        }

        public void createRoom(Player p1, int rmNumber) 
        {
            Match match = new Match(rmNumber,p1);
            matches.Add(match);
            MyMatchList(matches);
        }

        public void joinRoom(Player p2, int rmNumber) 
        {
            Match match = new Match();
            foreach (Match m in matches) 
            {
                if (m.RmNumber == rmNumber) 
                {
                    match = m;
                }
            }
            match.Player2 = p2;
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

        public void SubscribeMatch() 
        { }

        public void UnSubscribeMatch() 
        { }
        public void SubscribeListPlayers()
        {
            ILobbyCallback clientCallback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
            MyPlayerList += clientCallback.updatePlayerList;
            MyMessageSent += clientCallback.updateChatBox;
            MyMatchList += clientCallback.updateMatchList;

        }

        public void UnSubscribeListPlayers()
        {
            ILobbyCallback clientCallback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
            MyPlayerList -= clientCallback.updatePlayerList;
            MyMessageSent -= clientCallback.updateChatBox;
            MyMatchList -= clientCallback.updateMatchList;
        }

        public void SubscribeLobby() 
        {
            ILobbyCallback clientCallback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
            sentChallenge += clientCallback.ChallengeSent;
            acceptedChallenge += clientCallback.ChallengeAccepted;
            deniedChallenge += clientCallback.ChallengeDenied;
        }

        public void UnSubscribeLobby() 
        {
            ILobbyCallback clientCallback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
            sentChallenge -= clientCallback.ChallengeSent;
            acceptedChallenge -= clientCallback.ChallengeAccepted;
            deniedChallenge -= clientCallback.ChallengeDenied;
        }

        public List<string> getOnlinePlayers()
        {
            onlinePlayers = dh.getOnlinePlayers();
            return onlinePlayers;
        }

        public List<Player> getPlayers() 
        {
            return players;
        }

        public void SendMessage(string message, DateTime time)
        {
            string msg = new ChatMessage(message, time).StringMessage();
            MyMessageSent(msg);
        }

        public string GetChatMessage() 
        {
            return lobbyChat.ElementAt(lobbyChat.Count - 1);
        }

        public void sendChallenge(string p1, string p2) 
        {
            sendChallenge(p1, p2);
        }

        public void answerChallenge(Player p1, Player p2, bool answer) 
        {

        }

        //public void SubscribeChatBox()
        //{
        //    ILobbyCallback clientCallback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
        //    MyMessageSent += clientCallback.updateChatBox;
        //}

        //public void UnSubscribeChatBox()
        //{
        //    ILobbyCallback clientCallback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
        //    MyMessageSent -= clientCallback.updateChatBox;
        //}
    }
}
