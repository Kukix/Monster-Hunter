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
    public partial class Game : Form, MonsterFeastService.IGameCallback
    {
        private static MonsterFeastService.Player player1;
        private static MonsterFeastService.Player player2;
        MonsterFeastService.GameClient gameProxy;
        bool player1isSet = false;
        bool player2isSet = false;

        public Game(int roomNr)
        {
            InitializeComponent();
            gameProxy = new MonsterFeastService.GameClient(new InstanceContext(this));
            if (player1isSet == false)
            {
                player1 = Lobby.Player;
                player1isSet = true;
            }
            else if (player2isSet == false)
            {
                player2 = Lobby.Player;
                player2isSet = true;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //gameProxy.Subscribe();
            if(player1isSet)
            lbPlayerHealth.Text = player1.Username;
            if (player2isSet)
                lbOpponentHealth.Text = player2.Username;
        }

        public void TurnStart()
        {
            throw new NotImplementedException();
        }

        public void TurnEnded()
        {
            throw new NotImplementedException();
        }
    }
}
