using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;
//using System.Windows.Forms;

namespace MonsterFeastService
{
    class Connection
    {
        public string connString { get; private set; }

        public Connection()
        {     
            this.connString = "Server=localhost;database=mdw;uid=root;pwd=redranger";
        }
    }
    class DataHelper
    {
        Connection connect = new Connection();

        public Player GetPlayer(string username, string password)
        {
            try
            {
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                Player player = new Player();
                string sql = "SELECT * FROM user WHERE Username = '" + username + "'" + " AND Password = '" + password + "'";
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
                            player = new Player(Id, Username, Wins, Loses);
                            
                        }
                    }
                    reader.Close();
                }

                connection.Close();
                return player;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public Character GetCharacter(int id)
        {
            try
            {
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                Character playerCharacter = new Character();
                string sql = "SELECT * FROM character WHERE User_idUser= '" + id + "'";
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
                }
                connection.Close();
                return playerCharacter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public List<Skill> GetSkills(int idCharacter) { return null; }/* 
        {
            try
            {
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                //string sql = "SELECT * FROM skill WHERE [User_idUser]= '" + idCharacter + "'";
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return null;
            }
        }*/

        public void RegisterPlayer(string username, string password)
        {
            
        }

        public List<string> getOnlinePlayers() 
        {
            try 
            {
                List<string> players = new List<string>();
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                string sql = "SELECT * FROM user";
                MySqlCommand command = new MySqlCommand(sql, connection);
                using (MySqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            //add to the food list here.
                            players.Add(reader.GetString("Username"));
                        }
                    }
                    reader.Close();
                    return players;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Register(string username,string password)
        {
            try
            {
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                string sql = "INSERT INTO user (Username,Password) VALUES (@Username, @Password)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add("@Username", username);
                command.Parameters.Add("@Password", password);
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdatePlayer(Enum attribute)
        {
            throw new System.NotImplementedException();
        }
    }
}