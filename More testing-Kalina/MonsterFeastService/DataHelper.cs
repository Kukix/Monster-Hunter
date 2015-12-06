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
            this.connString = "Server=localhost;database=mdw;uid=root;pwd=snow";
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

        public Player getOpponent(string username) 
        {
            try
            {
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                Player player = new Player();
                string sql = "SELECT * FROM user WHERE Username = '" + username +"'";
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

        public bool hasCharacter(string username) 
        {
            bool check = false;
            try
            {
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                string sql = "SELECT hasChar FROM mdw.user WHERE username ='" + username + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            bool hasChar = (bool)reader.GetBoolean("hasChar");
                            check = hasChar;
                        }
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return check;

        }

        public void createCharacter(int id, string name,CharClass charClass,Element element) 
        {
            try
            {
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                string c = charClass.ToString();
                string e = element.ToString();
                int strength = 10, constitution = 10, magic = 10, wisdom = 10, dexterity = 10, agility = 10;
                if (charClass == CharClass.Warrior) 
                {
                    strength = strength + 2;
                    constitution = constitution + 1;
                }
                if (charClass == CharClass.Wizard) 
                {
                    magic = magic + 2;
                    wisdom = wisdom + 1;
                }
                if (charClass == CharClass.Archer) 
                {
                    dexterity = dexterity + 2;
                    agility = agility + 1;
                }
                //string sql = "INSERT INTO mdw.character (idCharacter,CharacterName,Class,Element,User_idUser) VALUES (" + id + ", '" + name + "','"+c+"','"+e+"',"+id+")";
                string sql = "INSERT INTO mdw.character (idCharacter,CharacterName,Class,Element,Strength,Constitution,Magic,Wisdom,Dexterity,Agility,User_idUser) SELECT " 
                    + id + ",'" + name + "','" + c + "','" + e + "',"+strength+","+constitution+","+magic+","+wisdom+","+dexterity+","+agility+"," + id 
                    + " FROM mdw.user WHERE mdw.user.idUser =" + id;
                MySqlCommand command = new MySqlCommand(sql, connection);
                string sql2 = "UPDATE mdw.user SET hasChar=" + true + " WHERE idUser="+id;
                MySqlCommand command2 = new MySqlCommand(sql2, connection);
                command.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                string sql = "SELECT * FROM mdw.character WHERE User_idUser=" + id;
                //string strSQL = string.Format("Select * From character where User_idUser = {0}", id);
                MySqlCommand command = new MySqlCommand(sql, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            int idCharacter = (int)reader.GetInt32("idCharacter");
                            string name = (string)reader.GetString("CharacterName");
                            int level = (int)reader.GetInt32("Lv");
                            int exp = (int)reader.GetInt32("Experience");
                            string e = (string)reader.GetString("Element");
                            Element element = (Element)Enum.Parse(typeof(Element), e, true);
                            //CharClass charClass = (CharClass)reader.GetOrdinal("Class");
                            string c = (string)reader.GetString("Class");
                            CharClass charClass = (CharClass)Enum.Parse(typeof(CharClass), c, true);
                            int strength = (int)reader.GetInt32("Strength");
                            int constitution = (int)reader.GetInt32("Constitution");
                            int magic = (int)reader.GetInt32("Magic");
                            int wisdom = (int)reader.GetInt32("Wisdom");
                            int dexterity = (int)reader.GetInt32("Dexterity");
                            int agility = (int)reader.GetInt32("Agility");
                            int attributePoints = (int)reader.GetInt32("AttributePoints");
                            int skillPoints = (int)reader.GetInt32("SkillPoints");
                            playerCharacter = new Character(name,level, exp, charClass, element, attributePoints,skillPoints, strength, constitution, magic, wisdom, dexterity, agility);

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
                    connection.Close();
                    return players;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool isRegistered(string username) 
        {
            bool check = false;
            try
            {
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                string sql = "SELECT * FROM user WHERE username ='"+username +"'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            check = true;
                        }
                        else check = false;
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return check;
        }

        public void Register(string username,string password)
        {
            try
            {
                string Connect = connect.connString;
                MySqlConnection connection = new MySqlConnection(Connect);
                connection.Open();

                string sql = "INSERT INTO mdw.user (Username,Password) VALUES ('"+username+"', '"+password+"')";
                MySqlCommand command = new MySqlCommand(sql, connection);
                //command.CommandType = System.Data.CommandType.Text;
                //command.Parameters.AddWithValue("@Username", username);
                //command.Parameters.AddWithValue("@Password", password);
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

        public void updateAttributes(string name, int strength, int constitution, int magic, int wisdom, int dexterity, int agility, int attributePoints) 
        {
            string Connect = connect.connString;
            MySqlConnection connection = new MySqlConnection(Connect);
            connection.Open();

            string sql = "UPDATE mdw.character SET Strength=" + strength + ", Constitution=" + constitution + ", Magic=" + magic + ",Wisdom=" + wisdom + ",Dexterity=" + dexterity + ",Agility=" + agility + ",AttributePoints=" + attributePoints + " WHERE CharacterName='" + name + "'";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}