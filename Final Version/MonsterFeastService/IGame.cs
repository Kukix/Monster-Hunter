using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace MonsterFeastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "MonsterFeastService", CallbackContract = typeof(IGameCallback))]
    public interface IGame
    {
        [OperationContract]
        void attack(Player attacker, Player defender, string skill, double HP);

        [OperationContract]
        void usePoint();

        [OperationContract]
        void giveUp();

        [OperationContract]
        void EndGame(Match m);

        [OperationContract]
        void Chat(string message);

        [OperationContract]
        string GetChat();

        [OperationContract]
        void endTurn(Player p);

        //[OperationContract]
        //void TurnStart();

        [OperationContract]
        void SendNotify(string act, string player);

        [OperationContract]
        void SubscribeGame();

        [OperationContract]
        void UnSbuscribeGame();
    }
    public interface IGameCallback
    {
        //[OperationContract(IsOneWay = true)]
        //void TurnStart();

        [OperationContract(IsOneWay = true)]
        void TurnEnded();

        [OperationContract(IsOneWay = true)]
        void updateHistoryBox(string message);

        [OperationContract(IsOneWay = true)]
        void updateHealth(double health, Player p);

        [OperationContract(IsOneWay = true)]
        void finishedGame(string message);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCFTest.ContractType".
    [DataContract]
    public class Player
    {
        int id;
        string username;
        Character character;
        int wins;
        int loses;

        public Player()
        {

        }

        public Player(int id, string name, int wins, int loses)
        {
            this.id = id;
            this.username = name;
            this.character = null;
            this.wins = wins;
            this.loses = loses;
        }

        [DataMember]
        public int Id 
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public Character Character
        {
            get { return character; }
            set { character = value; }
        }

        [DataMember]
        public int Wins
        {
            get { return wins; }
            set { wins = value; }
        }

        [DataMember]
        public int Loses
        {
            get { return loses; }
            set { loses = value; }
        }

    }

    [DataContract]
    public class Character
    {
        string name;
        int level;
        int exp;
        List<Skill> skills;
        CharClass charClass;
        Element charElement;
        int attributePoints;
        int skillPoints;
        int strength;
        int constitution;
        int magic;
        int wisdom;
        int dexterity;
        int agility;

        public Character() { }

        public Character(string name,int level, int experience, CharClass charClass, Element element, int attributePoints, int skillPoints, int strength, int constitution, int magic, int wisdom, int dexterity, int agility)
        {
            this.name = name;
            this.level = level;
            this.exp = experience;
            this.charClass = charClass;
            this.Element = element;
            this.attributePoints = attributePoints;
            this.skillPoints = skillPoints;
            this.strength = strength;
            this.constitution = constitution;
            this.magic = magic;
            this.wisdom = wisdom;
            this.dexterity = dexterity;
            this.agility = agility;
        }

        [DataMember]
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        [DataMember]
        public int Experience
        {
            get { return exp; }
            set { exp = value; }
        }

        [DataMember]
        public CharClass CharClass
        {
            get { return charClass; }
            set { charClass = value; }
        }

        [DataMember]
        public Element Element
        {
            get { return charElement; }
            set { charElement = value; }
        }

        [DataMember]
        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        [DataMember]
        public int Constitution
        {
            get { return constitution; }
            set { constitution = value; }
        }
        [DataMember]
        public int Magic
        {
            get { return magic; }
            set { magic = value; }
        }
        [DataMember]
        public int Wisdom
        {
            get { return wisdom; }
            set { wisdom = value; }
        }
        [DataMember]
        public int Dexterity
        {
            get { return dexterity; }
            set { dexterity = value; }
        }
        [DataMember]
        public int Agility
        {
            get { return agility; }
            set { agility = value; }
        }

        [DataMember]
        public int AttributePoints
        {
            get { return attributePoints; }
            set { attributePoints = value; }
        }

        [DataMember]
        public int SkillPoints 
        {
            get { return skillPoints; }
            set { skillPoints = value; }
        }

        [DataMember]
        public List<Skill> Skills
        {
            get { return skills; }
            set { skills = value; }
        }
    }

    [DataContract]
    public class Skill
    {
        private int idSkill;
        private string skillName;
        private int attackStrength;
        private Element element;
        private string description;
        private int skillLv;

        public Skill(int id, string name, int strength, Element element, string description, int lv)
        {
            this.idSkill = id;
            this.skillName = name;
            this.attackStrength = strength;
            this.element = element;
            this.description = description;
            this.skillLv = lv;
        }

        [DataMember]
        public int IdSkill
        {
            get { return idSkill; }
            set { idSkill = value; }
        }

        [DataMember]
        public string SkillName
        {
            get { return skillName; }
            set { skillName = value; }
        }

        public int AttackStrength
        {
            get { return attackStrength; }
            set { attackStrength = value; }
        }

        [DataMember]
        public Element Element
        {
            get { return element; }
            set { element = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int SkillLv
        {
            get { return skillLv; }
            set { skillLv = value; }
        }
    }
    
    [DataContract]
    public class ChatMessage
    {
        //private Player player;
        private string message;
        private DateTime date;

        //[DataMember]
        //public Player Player
        //{
        //    get { return player; }
        //    set { player = value; }
        //}


        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public ChatMessage(string message, DateTime time)
        {
            //this.player = p;
            this.message = message;
            //this.date = time;
        }

        public string StringMessage()
        {
            return message;
        }
    }

    [DataContract]
    public class Match
    {
        private int rmNumber;
        private Player player1, player2;
        private Player turn;
        private List<string> gameChat;

        [DataMember]
        public int RmNumber
        {
            get { return rmNumber; }
            set { rmNumber = value; }
        }

        [DataMember]
        public Player Player1
        {
            get { return player1; }
            set { player1 = value; }
        }

        [DataMember]
        public Player Player2
        {
            get { return player2; }
            set { player2 = value; }
        }

        [DataMember]
        public Player Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        [DataMember]
        public List<string> GameChat
        {
            get;
            set;
        }

        public Match() { }

        public Match(int rmNumber, Player player1)
        {
            this.player1 = player1;
            this.rmNumber = rmNumber;
            this.turn = player1;
            this.GameChat = new List<string>();
        }

    }
}
