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
    public partial class Form1 : Form, MonsterFeastService.ILobbyCallback
    {
        MonsterFeastService.LobbyClient lobbyProxy;
        private static MonsterFeastService.Player player;
        List<string> players;
        public Form1()
        {
            InitializeComponent();
            lobbyProxy = new MonsterFeastService.LobbyClient(new InstanceContext(this));
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

        private void button1_Click(object sender, EventArgs e)
        {
            players = lobbyProxy.getOnlinePlayers();
            foreach(string st in players)
            {
                listBox1.Items.Add(st);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            player = lobbyProxy.Login(username, password);
            lobbyProxy.addToList(player);

            Lobby lobbyform = new Lobby();
            lobbyform.Show();
            this.Hide();

            listBox1.Items.Add(player.Wins.ToString());
        }

        public void updateChatBox(MonsterFeastService.Player p, string message)
        {
            throw new NotImplementedException();
        }

        public void updatePlayerList(List<MonsterFeastService.Player> players)
        {
            throw new NotImplementedException();
        }
    }
}
