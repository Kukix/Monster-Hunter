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
    public class CGame : IGame, ILobby, ILogin
    {
        // ---------------------------------------- PROPERTIES ----------------------------------------
        private bool isStart;
        private bool isEnd;
        List<string> onlinePlayers;
        private List<string> lobbyChat;
        private List<string> gameHistory;
        DataHelper dh = new DataHelper();
        private List<Player> players;
        private List<Match> matches;
        Random r;

        // ---------------------------------------- CALLBACKS & EVENTS ----------------------------------------
        private Action<List<Player>> MyPlayerList = delegate { };
        private Action<List<Match>> MyMatchList = delegate { };
        private Action<string> MyMessageSent = delegate { };
        private Action<string, string> sentChallenge = delegate { };
        private Action<string, Match> acceptedChallenge = delegate { };
        private Action<string> deniedChallenge = delegate { };
        private Action<Match> isReady = delegate { };
        private Action<string> Notified = delegate { };
        private Action TurnEnd = delegate { };
        private Action<double, Player> UpdateHealth = delegate { };
        private Action<string> isFinished = delegate { };
        // ---------------------------------------- CONSTRUCTOR ----------------------------------------
        public CGame()
        {
            players = new List<Player>();
            lobbyChat = new List<string>();
            gameHistory = new List<string>();
            matches = new List<Match>();
            r = new Random();
        }

        // ---------------------------------------- ILOGIN ----------------------------------------
        #region ILogin
        public bool isRegistered(string username)
        {
            return dh.isRegistered(username);
        }
        public void Register(string username, string password)
        {
            dh.Register(username, password);
        }
        public Player Login(string username, string password)
        {
            Player player1 = new Player();
            player1 = dh.GetPlayer(username, password);
            //MyPlayerList(players);
            return player1;
        }
        public bool hasChar(string username)
        {
            return dh.hasCharacter(username);
        }
        public void createCharacter(int id, string name, CharClass charClass, Element element)
        {
            dh.createCharacter(id, name, charClass, element);
        }
        public void addToList(Player p)
        {
            players.Add(p);
            MyPlayerList(players);
        }
        #endregion

        // ---------------------------------------- ILOBBY ----------------------------------------
        #region ILobby
        public void FindMatch(Player p)
        {
            if (getMatches().Count == 0)
            {
                int nr = r.Next(1, 99);
                foreach (Match m in matches)
                {
                    if (m.RmNumber == nr)
                    {
                        nr = r.Next(1, 99);
                    }
                }
                createRoom(p, nr);
            }
            else
            {
                joinRoom(p);
            }
        }
        public void AllocateAttribute(Attribute a)
        {
            throw new NotImplementedException();
        }
        public List<string> getOnlinePlayers()
        {
            onlinePlayers = dh.getOnlinePlayers();
            return onlinePlayers;
        }
        public Player getPlayer(string username)
        {
            return dh.getOpponent(username);
        }
        public List<Player> getPlayers()
        {
            return players;
        }
        public List<Match> getMatches()
        {
            List<Match> temp = new List<Match>();
            foreach (Match m in matches)
            {
                if (m.Player2 == null)
                {
                    temp.Add(m);
                }
            }

            return temp;
        }
        public Character getCharacter(int id)
        {
            Character playerCharacter = new Character();
            playerCharacter = dh.GetCharacter(id);
            playerCharacter.Skills = dh.GetSkills(id);
            return playerCharacter;
        }
        public void sendChallenge(string p1, string p2)
        {
            sendChallenge(p1, p2);
        }
        public void answerChallenge(Player p1, Player p2, bool answer)
        {

        }
        public void updateAttributes(string name, int strength, int constitution, int magic, int wisdom, int dexterity, int agility, int attributePoints)
        {
            dh.updateAttributes(name, strength, constitution, magic, wisdom, dexterity, agility, attributePoints);
        }
        public void createRoom(Player p1, int rmNumber)
        {
            Match match = new Match(rmNumber, p1);
            matches.Add(match);
            MyMatchList(matches);
        }
        public void joinRoom(Player p2)
        {
            Match match = new Match();
            foreach (Match m in matches)
            {
                if (m.RmNumber == getMatches()[0].RmNumber)
                {
                    match = m;
                }
            }
            match.Player2 = p2;

            isReady(match);
        }
        public void Logout(Player player)
        {
            var playerToRemove = players.Single(r => r.Username == player.Username);
            if (playerToRemove != null)
                {
                    players.Remove(playerToRemove);
                }
            MyPlayerList(players);
        }
        #endregion
        #region callback

        #endregion

        #region IChat
        public void SendMessage(string message, DateTime time)
        {
            string msg = new ChatMessage(message, time).StringMessage();
            MyMessageSent(msg);
        }

        public string GetChatMessage()
        {
            return lobbyChat.ElementAt(lobbyChat.Count - 1);
        }
        #endregion

        // ---------------------------------------- IGAME ----------------------------------------
        #region IGame
        public void attack(Player attacker, Player defender, string skill, double HP)
        {
            double classModifier = 1, elementModefier = 1, skillModifier = 1;

            if (skill == "SkillA")
            {
                skillModifier = 1.2;
            }
            else
            {
                skillModifier = 0.8;
            }

            //switch (attacker.Character.CharClass)
            //{
            //    case CharClass.Warrior:
            //        switch (defender.Character.CharClass)
            //        {
            //            case CharClass.Warrior:
            //                break;
            //            case CharClass.Wizard:
            //                classModifier = 0.8;
            //                break;
            //            case CharClass.Archer:
            //                classModifier = 1.2;
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    case CharClass.Wizard:
            //        switch (defender.Character.CharClass)
            //        {
            //            case CharClass.Warrior:
            //                classModifier = 1.2;
            //                break;
            //            case CharClass.Wizard:
            //                break;
            //            case CharClass.Archer:
            //                classModifier = 0.8;
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    case CharClass.Archer:
            //        switch (defender.Character.CharClass)
            //        {
            //            case CharClass.Warrior:
            //                classModifier = 0.8;
            //                break;
            //            case CharClass.Wizard:
            //                classModifier = 1.2;
            //                break;
            //            case CharClass.Archer:
            //                break;
            //            default:
            //                break;
            //        }
            //        break;
            //    default:
            //        break;
            //}
            
            //#region classModifier
            //if (attacker.Character.CharClass == CharClass.Archer)
            //{
            //    if (defender.Character.CharClass == CharClass.Wizard)
            //    {
            //        classModifier = 1.2;
            //    }
            //    if (defender.Character.CharClass == CharClass.Warrior)
            //    {
            //        classModifier = 0.8;
            //    }
            //}
            //if (attacker.Character.CharClass == CharClass.Wizard)
            //{
            //    if (defender.Character.CharClass == CharClass.Archer)
            //    {
            //        classModifier = 0.8;
            //    }
            //    if (defender.Character.CharClass == CharClass.Warrior)
            //    {
            //        classModifier = 1.2;
            //    }
            //}
            //if (attacker.Character.CharClass == CharClass.Warrior)
            //{
            //    if (defender.Character.CharClass == CharClass.Archer)
            //    {
            //        classModifier = 1.2;
            //    }
            //    if (defender.Character.CharClass == CharClass.Wizard)
            //    {
            //        classModifier = 0.8;
            //    }
            //}
            //#endregion
            //#region elementModifier
            //if (attacker.Character.Element == Element.Water)
            //{
            //    if (defender.Character.Element == Element.Fire)
            //        elementModefier = 1.2;
            //    if (defender.Character.Element == Element.Earth)
            //        elementModefier = 0.8;
            //}
            //if (attacker.Character.Element == Element.Fire)
            //{
            //    if (defender.Character.Element == Element.Air)
            //        elementModefier = 1.2;
            //    if (defender.Character.Element == Element.Water)
            //        elementModefier = 0.8;
            //}
            //if (attacker.Character.Element == Element.Air)
            //{
            //    if (defender.Character.Element == Element.Earth)
            //        elementModefier = 1.2;
            //    if (defender.Character.Element == Element.Fire)
            //        elementModefier = 0.8;
            //}
            //if (attacker.Character.Element == Element.Earth)
            //{
            //    if (defender.Character.Element == Element.Water)
            //        elementModefier = 1.2;
            //    if (defender.Character.Element == Element.Air)
            //        elementModefier = 0.8;
            //}
            //#endregion

            ////double Hp = HP - skill.AttackStrength * classModifier * elementModefier * skillModifier;
            double attacked = 10 * skillModifier;
            double Hp = HP - attacked;
            if (Hp <= 0)
            {
                //fire end Game event
                //endGame(attacker, defender);
                SendNotify(("Yeay you win!"), (attacker.Username));
                UpdateHealth(Hp, defender);
                isFinished("Finished");
            }
            else
            {
                SendNotify(("Attacked " + defender.Username + " with " + attacked + " Hit Points."), (attacker.Username));
                UpdateHealth(Hp, defender);
                TurnEnd();
            }
        }

        public void usePoint() { }

        public void endTurn(Player p)
        {
            SendNotify("Ended his turn", p.Username);
            TurnEnd();
        }

        public void giveUp() { }

        public void EndGame(Match m) {
            var matchToRemove = matches.Single(r => r.RmNumber == m.RmNumber);
            if (matchToRemove != null)
            {
                matches.Remove(matchToRemove);
            }
            MyMatchList(matches);
        }

        public void Chat(string message)
        {
            Notified(message);
        }

        public string GetChat()
        {
            return gameHistory.ElementAt(gameHistory.Count - 1);
        }

        public void SendNotify(string act, string player)
        {
            string notify = player + " " + act;
            Notified(notify);
        }
        #endregion

        // ---------------------------------------- SUBSCRIBERS ----------------------------------------
        #region Unused
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
        #endregion

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
            isReady += clientCallback.GameReady;
        }
        public void UnSubscribeLobby()
        {
            ILobbyCallback clientCallback = OperationContext.Current.GetCallbackChannel<ILobbyCallback>();
            sentChallenge -= clientCallback.ChallengeSent;
            acceptedChallenge -= clientCallback.ChallengeAccepted;
            deniedChallenge -= clientCallback.ChallengeDenied;
            isReady += clientCallback.GameReady;
        }

        public void SubscribeGame()
        {
            IGameCallback clientCallback = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            Notified += clientCallback.updateHistoryBox;
            TurnEnd += clientCallback.TurnEnded;
            UpdateHealth += clientCallback.updateHealth;
            isFinished += clientCallback.finishedGame;
        }
        public void UnSbuscribeGame()
        {
            IGameCallback clientCallback = OperationContext.Current.GetCallbackChannel<IGameCallback>();
            Notified -= clientCallback.updateHistoryBox;
            TurnEnd -= clientCallback.TurnEnded;
            UpdateHealth -= clientCallback.updateHealth;
            isFinished -= clientCallback.finishedGame;
        }

        #region the rest
        public int calculateDamage(Player attacker, Player defender) { return 0; }

        public int calculateHP(Player defender, int damage) { return 0; }

        public int calculateExp(Player p) { return 0; }

        public void changeTurn() { }

#endregion
    }
}
