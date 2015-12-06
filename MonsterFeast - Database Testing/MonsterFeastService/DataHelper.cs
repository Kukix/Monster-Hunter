using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
//using System.Windows.Forms;

namespace MonsterFeastService
{
    class Connection
    {
        public string Connection { get; private set; }

        public Connection()
        {
            FileStream fs = new FileStream("../../../connection_local.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            this.Connection = sr.ReadLine();
            //this.Connection = "server=athena01.fhict.local;Uid=dbi289315;Pwd=ZuD7UVJ5jv;Database=dbi289315;";
            sr.Dispose();
            fs.Dispose();
        }
    }
    class DataHelper
    {
        Connection connect = new Connection();
        private int player1id;
        private int player2id;

        public Player GetPlayer(string username, string password)
        {
            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                string sql = "SELECT * FROM user WHERE [Username] = '" + username + "'" + " AND [Password] = '" + password + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            int Id = (int)reader.GetInt32("idUser");
                            string Username = (string)reader.GetString("Username");
                            int Wins = (int)reader.GetInt32("Wins");
                            int Loses = (int)reader.GetInt32("Loses");
                            bool HasChar = (bool)reader.GetBoolean("HasChar");
                            if (HasChar == true)
                            {
                                GetCharacter(Id);
                            }
                        }
                    }
                    reader.Close();
                }
                Player player = new Player();

                connection.Close();
                return player;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Character GetCharacter(int id)
        {
            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                Character playerCharacter = new Character();
                string sql = "SELECT * FROM character WHERE [User_idUser]= '" + id + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            int idCharacter = (int)reader.GetInt32("idCharacter");
                            int level = (int)reader.GetInt32("Lv");
                            int exp = (int)reader.GetInt32("Experience");
                            //Element element = (Enum)reader.GetEnumerator("Element");
                            //CharClass charClass = (CharClass)reader.GetEnumerator("Class");
                            int strength = (int)reader.GetInt32("Strength");
                            int constitution = (int)reader.GetInt32("Constitution");
                            int magic = (int)reader.GetInt32("Magic");
                            int wisdom = (int)reader.GetInt32("Wisdom");
                            int dexterity = (int)reader.GetInt32("Dexterity");
                            int agility = (int)reader.GetInt32("Agility");
                            int attributePoints = (int)reader.GetInt32("AttributePoints");
                            playerCharacter = new Character(level, exp, attributePoints, strength, constitution, magic, wisdom, dexterity, agility);

                        }
                    }
                    reader.Close();
                    return playerCharacter;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public List<Skill> GetSkills(int idCharacter) 
        {
            try
            {
                string Connect = connect.Connection;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                string sql = "SELECT * FROM skill WHERE [User_idUser]= '" + idCharacter + "'";
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public void RegisterPlayer()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePlayer()
        {
            throw new System.NotImplementedException();
        }
    }
}