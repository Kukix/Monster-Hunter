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
    [CallbackBehavior(ConcurrencyMode=ConcurrencyMode.Multiple,UseSynchronizationContext = false)]
    public partial class Lobby : Form, MonsterFeastService.ILobbyCallback
    {
        MonsterFeastService.LobbyClient lobbyProxy;
        MonsterFeastService.Character character;
        private static MonsterFeastService.Player p = Login.Player;
        public Lobby()
        {
            InitializeComponent();
            lobbyProxy = new MonsterFeastService.LobbyClient(new InstanceContext(this));

            //lobbyProxy.SubscribeChatBox();
            //lobbyProxy.SubscribeListPlayers();
            //lobbyProxy.addToList(p);
            List<MonsterFeastService.Player> onlinePlayers = lobbyProxy.getPlayers();
            foreach (MonsterFeastService.Player p in onlinePlayers) 
            {
                listBox1.Items.Add(p.Username);
            }
        }
        
        private void Lobby_Load(object sender, EventArgs e)
        {
            lobbyProxy.SubscribeListPlayers();
            lobbyProxy.SubscribeLobby();
            label1.Text = p.Username;
            character = lobbyProxy.getCharacter(p.Id);
            p.Character = character;
            lbCharName.Text = character.Name;
            lbStrength.Text = character.Strength.ToString();
            lbConstitution.Text = character.Constitution.ToString();
            lbMagic.Text = character.Magic.ToString();
            lbWisdom.Text = character.Wisdom.ToString();
            lbDexterity.Text = character.Dexterity.ToString();
            lbAgility.Text = character.Agility.ToString();
            lbAbilityPoints.Text = character.AttributePoints.ToString();
            lbSkillPoints.Text = character.SkillPoints.ToString();
            lbLevel.Text = character.Level.ToString();
            lbExp.Text = character.Experience.ToString();
            lbClass.Text = character.CharClass.ToString();
            lbElement.Text = character.Element.ToString();
            if (character.AttributePoints > 0)
                this.showButtons();


            //foreach (MonsterFeastService.Player p in players) 
            //{
            //    listBox1.Items.Add(p.Username);
            //}

        }

        public static MonsterFeastService.Player Player
        {
            get { return p; }
            set { p = value; }
        }

        private void hideButtons()
        {
            btnStrength.Visible = false;
            btnConstitution.Visible = false;
            btnMagic.Visible = false;
            btnWisdom.Visible = false;
            btnDexterity.Visible = false;
            btnAgility.Visible = false;
        }

        private void showButtons()
        {
            btnStrength.Visible = true;
            btnConstitution.Visible = true;
            btnMagic.Visible = true;
            btnWisdom.Visible = true;
            btnDexterity.Visible = true;
            btnAgility.Visible = true;
        }

        private void btnStrength_Click(object sender, EventArgs e)
        {
            character.Strength++;
            character.AttributePoints--;
            if (character.AttributePoints == 0)
                this.hideButtons();
            lbStrength.Text = character.Strength.ToString();
            lbAbilityPoints.Text = character.AttributePoints.ToString();
        }

        private void btnConstitution_Click(object sender, EventArgs e)
        {
            character.Constitution++;
            character.AttributePoints--;
            if (character.AttributePoints == 0)
                this.hideButtons();
            lbConstitution.Text = character.Constitution.ToString();
            lbAbilityPoints.Text = character.AttributePoints.ToString();
        }

        private void btnMagic_Click(object sender, EventArgs e)
        {
            character.Magic++;
            character.AttributePoints--;
            if (character.AttributePoints == 0)
                this.hideButtons();
            lbMagic.Text = character.Magic.ToString();
            lbAbilityPoints.Text = character.AttributePoints.ToString();
        }

        private void btnWisdom_Click(object sender, EventArgs e)
        {
            character.Wisdom++;
            character.AttributePoints--;
            if (character.AttributePoints == 0)
                this.hideButtons();
            lbWisdom.Text = character.Wisdom.ToString();
            lbAbilityPoints.Text = character.AttributePoints.ToString();
        }

        private void btnDexterity_Click(object sender, EventArgs e)
        {
            character.Dexterity++;
            character.AttributePoints--;
            if (character.AttributePoints == 0)
                this.hideButtons();
            lbDexterity.Text = character.Dexterity.ToString();
            lbAbilityPoints.Text = character.AttributePoints.ToString();
        }

        private void btnAgility_Click(object sender, EventArgs e)
        {
            character.Agility++;
            character.AttributePoints--;
            if (character.AttributePoints == 0)
                this.hideButtons();
            lbAgility.Text = character.Agility.ToString();
            lbAbilityPoints.Text = character.AttributePoints.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            lobbyProxy.updateAttributes(character.Name, character.Strength,character.Constitution,character.Magic,character.Wisdom,character.Dexterity,character.Agility,character.AttributePoints);
        }

        public void updateChatBox(string message)
        {
            this.Invoke(new MethodInvoker(delegate()
                {
                    textBox1.AppendText(message + System.Environment.NewLine);
                    //listBox1.Items.Add(message);
                }));
        }

        public void updatePlayerList(List<MonsterFeastService.Player> players)
        {
            this.Invoke(new MethodInvoker(delegate()
                {
                    listBox1.Items.Clear();
                    foreach (MonsterFeastService.Player p in players)
                    {
                        listBox1.Items.Add(p.Username);
                    }
                }));
        }

        public void updateMatchList(List<MonsterFeastService.Match> matches) 
        {
             this.Invoke(new MethodInvoker(delegate()
                {
                    lbMatches.Items.Clear();
                    foreach (MonsterFeastService.Match match in matches) 
                    {
                        lbMatches.Items.Add(match.RmNumber);
                    }
                }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = p.Username + ": "+ textBox2.Text;
            lobbyProxy.SendMessage(message, DateTime.Now);
            textBox2.Clear();
        }

        public void ChallengeSent(string player1, string player2)
        {
            if (player2 == p.Username)
            {
                MessageBox.Show("You have been challenged.");
            }
            else 
            {
                textBox1.AppendText(player1 + " has challenged " + player2 + System.Environment.NewLine);
            }
        }

        public void ChallengeDenied(string player)
        {
            throw new NotImplementedException();
        }

        public void ChallengeAccepted(string player, MonsterFeastService.Match match)
        {
            throw new NotImplementedException();
        }

        public void GameCreated(MonsterFeastService.Player player1, MonsterFeastService.Player player2, MonsterFeastService.Match match, MonsterFeastService.Player currentPlayer)
        {
            throw new NotImplementedException();
        }

        private void Lobby_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void btnChallenge_Click(object sender, EventArgs e)
        {
            string opponent = listBox1.SelectedItem.ToString();
            //MonsterFeastService.Player opponent = lobbyProxy.getPlayer(Opponent);
            lobbyProxy.sendChallenge(p.Username,opponent);
        }

        private void Lobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.lobbyProxy.UnSubscribeListPlayers();
        }

        private void btnMatch_Click(object sender, EventArgs e)
        {
            int roomNr = 1;
            lobbyProxy.createRoom(p, 1);
            Game game = new Game(roomNr);
            game.Show();
            this.Hide();
        }

        private void lbMatches_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnJoinMatch_Click(object sender, EventArgs e)
        {
            int matchNr = Convert.ToInt32(lbMatches.SelectedItem);
            lobbyProxy.joinRoom(p, matchNr);

            Game game = new Game(matchNr);
            game.Show();
            this.Hide();
        }
    }
}
