using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ServiceModel;

namespace MonsterFeastClient
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public partial class Lobby : Window, MonsterFeastService.ILobbyCallback
    {
        // ---------------------------------------- PROPERTIES ----------------------------------------
        MonsterFeastService.LobbyClient lobbyProxy;
        MonsterFeastService.Character character;
        private static MonsterFeastService.Player p = Login.Player;
        MonsterFeastService.Player[] onlinePlayers;
        MonsterFeastService.Match[] onlineMatches;
        public static MonsterFeastService.Player Player
        {
            get { return p; }
            set { p = value; }
        }
        int count = 0;

        // ---------------------------------------- CONSTRUCTOR ----------------------------------------
        public Lobby()
        {
            InitializeComponent();
            lobbyProxy = new MonsterFeastService.LobbyClient(new InstanceContext(this));

            onlinePlayers = lobbyProxy.getPlayers();
            foreach (MonsterFeastService.Player ol in onlinePlayers)
            {
                lbOnline.Items.Add(ol.Username.ToString());
            }

            onlineMatches = lobbyProxy.getMatches();
            lbRooms.Items.Clear();
            foreach (MonsterFeastService.Match match in onlineMatches)
            {
                string roomName = "Room " + match.RmNumber;
                if (match.Player2 == null)
                {
                    roomName += " - Waiting";
                }
                else
                {
                    roomName += " - Playing";
                }
                lbRooms.Items.Add(roomName);
            }
            
            character = lobbyProxy.getCharacter(p.Id);
            
        }

        // ---------------------------------------- WINDOWS ----------------------------------------
        #region Events
        private void closeBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            lobbyProxy.Logout(p);
            lobbyProxy.UnSubscribeLobby();
            lobbyProxy.UnSubscribeListPlayers();
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lobbyProxy.SubscribeListPlayers();
            lobbyProxy.SubscribeLobby();
            loadData();
        }
        private void tbSend_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= tbSend_GotFocus;
        }
        private void tbSend_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text == string.Empty)
            {
                tb.Text = "Send your message";
            }
            else
            {
                tb.Text = tb.Text;
            }

            tb.LostFocus -= tbSend_LostFocus;
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Buttons
        private void btnStrength_Click(object sender, RoutedEventArgs e)
        {
            character.Strength++;
            character.AttributePoints--;
            updateAttribute();
            loadData();
        }

        private void btnWisdom_Click(object sender, RoutedEventArgs e)
        {
            character.Wisdom++;
            character.AttributePoints--;
            updateAttribute();
            loadData();
        }

        private void btnConstitution_Click(object sender, RoutedEventArgs e)
        {
            character.Constitution++;
            character.AttributePoints--;
            updateAttribute();
            loadData();
        }

        private void btnDexterity_Click(object sender, RoutedEventArgs e)
        {
            character.Dexterity++;
            character.AttributePoints--;
            updateAttribute();
            loadData();
        }

        private void btnMagic_Click(object sender, RoutedEventArgs e)
        {
            character.Magic++;
            character.AttributePoints--;
            updateAttribute();
            loadData();
        }

        private void btnAgility_Click(object sender, RoutedEventArgs e)
        {
            character.Agility++;
            character.AttributePoints--;
            updateAttribute();
            loadData();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string message = p.Username + ": " + tbSend.Text;
            lobbyProxy.SendMessage(message, DateTime.Now);
            tbSend.Clear();
            tbSend.Text = "Send your message";
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            lobbyProxy.FindMatch(p);
            btnFind.IsEnabled = false;
        }
        #endregion

        // ---------------------------------------- METHODS ----------------------------------------
        #region Services
        public void updateChatBox(string message)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                rbChat.AppendText(message + System.Environment.NewLine);
                rbChat.ScrollToEnd();
            }));
        }
        public void updatePlayerList(MonsterFeastService.Player[] players)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                players = lobbyProxy.getPlayers();
                lbOnline.Items.Clear();
                foreach (MonsterFeastService.Player ol in players)
                {
                    lbOnline.Items.Add(ol.Username.ToString());
                }
            }));
        }
        private void updateAttribute()
        {
            lobbyProxy.updateAttributes(character.Name, character.Strength, character.Constitution, character.Magic, character.Wisdom, character.Dexterity, character.Agility, character.AttributePoints);
        }
        public void updateMatchList(MonsterFeastService.Match[] matches)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                lbRooms.Items.Clear();
                foreach (MonsterFeastService.Match match in matches)
                {
                    string roomName = "Room " + match.RmNumber;
                    if (match.Player2 == null)
                    {
                        roomName += " - Waiting";
                    }
                    else
                    {
                        roomName += " - Playing";
                    }
                    lbRooms.Items.Add(roomName);
                }
            }));
        }
        public void GameReady(MonsterFeastService.Match m)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                Game game = new Game(m.RmNumber, m, p.Username);
                this.Visibility = Visibility.Hidden;
                game.ShowDialog();
                this.Visibility = Visibility.Visible;
                btnFind.IsEnabled = true;
            }));
        }

        #endregion

        #region Windows
        private void loadData()
        {
            lbName.Content = character.Name;
            lbWin.Content = p.Wins.ToString();
            lbLvl.Content = "Level " + character.Level.ToString();
            lbExp.Content = character.Experience.ToString() + " EXP";

            lbStrength.Content = character.Strength.ToString();
            lbConstitution.Content = character.Constitution.ToString();
            lbMagic.Content = character.Magic.ToString();
            lbWisdom.Content = character.Wisdom.ToString();
            lbDexterity.Content = character.Dexterity.ToString();
            lbAgility.Content = character.Agility.ToString();

            if (character.AttributePoints > 0)
            {
                ShowAbilitiesButtons();
                lbSkillPoints.Visibility = Visibility.Visible;
                lbSkillPoints.Content = character.AttributePoints.ToString() + " Points Left";
            }
            else
            {
                hideAbilitiesButtons();
                lbSkillPoints.Visibility = Visibility.Collapsed;
            }
        }

        public void hideAbilitiesButtons()
        {
            btnStrength.Visibility = Visibility.Collapsed;
            btnConstitution.Visibility = Visibility.Collapsed;
            btnMagic.Visibility = Visibility.Collapsed;
            btnWisdom.Visibility = Visibility.Collapsed;
            btnDexterity.Visibility = Visibility.Collapsed;
            btnAgility.Visibility = Visibility.Collapsed;
        }

        public void ShowAbilitiesButtons()
        {
            btnStrength.Visibility = Visibility.Visible;
            btnConstitution.Visibility = Visibility.Visible;
            btnMagic.Visibility = Visibility.Visible;
            btnWisdom.Visibility = Visibility.Visible;
            btnDexterity.Visibility = Visibility.Visible;
            btnAgility.Visibility = Visibility.Visible;
        }
        #endregion

        #region unused
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

        public void ChallengeSent(string player1, string player2)
        {
            if (player2 == p.Username)
            {
                MessageBox.Show("You have been challenged.");
            }
            else
            {
                //textBox1.AppendText(player1 + " has challenged " + player2 + System.Environment.NewLine);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //lobbyProxy.joinRoom(p);
        }
        #endregion




    }
}
