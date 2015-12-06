using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonsterFeastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "WCFTest", CallbackContract = typeof(IGameCallback))]
    public interface IGame
    {
        [OperationContract]
        void attack(Skill a);

        [OperationContract]
        void usePoint();

        [OperationContract]
        void giveUp();

        [OperationContract]
        void sendMessage(string message, Player sender, DateTime time);

        // TODO: Add your service operations here
    }
    public interface IGameCallback
    {

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

        public Player(int id, string name, Character character, int wins, int loses)
        {
            this.id = id;
            this.username = name;
            this.character = character;
            this.wins = wins;
            this.loses = loses;
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
            private set;
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
        int level;
        int exp;
        List<Skill> skills;
        CharClass charClass;
        Element charElement;
        int attributePoints;
        int strength;
        int constitution;
        int magic;
        int wisdom;
        int dexterity;
        int agility;

        [DataMember]
        public Character() { }

        [DataMember]
        public Character(int level, int experience, int attributePoints, int strength, int constitution, int magic, int wisdom, int dexterity, int agility)
        {
            this.level = level;
            this.exp = experience;
            //this.charClass = charClass;
            //this.Element = element;
            this.strength = strength;
            this.constitution = constitution;
            this.magic = magic;
            this.dexterity = dexterity;
            this.agility = agility;
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
    }

    [DataContract]
    public class Skill
    {
        public Skill()
        {
            throw new System.NotImplementedException();
        }

        public int IdPower
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        [DataMember]
        public string PowerName
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public int Attack
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        [DataMember]
        public Element Element
        {
            get;
            set;
        }

        [DataMember]
        public string Effect
        {
            get;
            set;
        }
    }
}
