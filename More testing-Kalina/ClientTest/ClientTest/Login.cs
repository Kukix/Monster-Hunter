using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace ClientTest
{
    public partial class Login : Form
    {
        MonsterFeastService.LoginClient loginProxy;
        private static MonsterFeastService.Player player;
        //List<string> players;
        public Login()
        {
            InitializeComponent();
            loginProxy = new MonsterFeastService.LoginClient();
            player = new MonsterFeastService.Player();
            //lobbyProxy.SubscribeChatBox();
            //lobbyProxy.SubscribeListPlayers();

            //players = new List<MonsterFeastService.Player>();
        }
        public static MonsterFeastService.Player Player
        {
            get { return player; }
            set { player = value; }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            player = loginProxy.Login(username, password);

            if (loginProxy.hasChar(player.Username))
            {
                loginProxy.addToList(player);
                this.Hide();
                Lobby lobbyform = new Lobby();
                lobbyform.Show();
            }
            else 
            {
                CharacterCreation createform = new CharacterCreation();
                createform.Show();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
        }
    }
}
