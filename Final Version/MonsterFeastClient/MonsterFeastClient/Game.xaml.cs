using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Game.xaml
    /// </summary>
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public partial class Game : Window, MonsterFeastService.IGameCallback
    {
        // ---------------------------------------- PROPERTIES ----------------------------------------
        private static MonsterFeastService.Player home;
        private static MonsterFeastService.Player opponent;
        private static MonsterFeastService.Player me;
        MonsterFeastService.GameClient gameProxy;
        MonsterFeastService.Match currentMatch;
        MonsterFeastService.Skill selectedSkill;

        // ---------------------------------------- CONSTRUCTOR ----------------------------------------
        public Game(int nr, MonsterFeastService.Match m, string myName)
        {
            gameProxy = new MonsterFeastService.GameClient(new InstanceContext(this));
            currentMatch = m;

            InitializeComponent();

            if (currentMatch.Player1.Username == myName)
            {
                me = currentMatch.Player1;
                home = currentMatch.Player1;
                opponent = currentMatch.Player2;
            }
            if (currentMatch.Player2.Username == myName)
            {
                me = currentMatch.Player2;
                home = currentMatch.Player2;
                opponent = currentMatch.Player1;
            }

            tbHome.Text = home.Username.ToString();
            tbOpponent.Text = opponent.Username.ToString();

            spNormalAttack.Visibility = Visibility.Collapsed;
            spSkills.Visibility = Visibility.Collapsed;

                pbHome.Value = 100;
                pbOpponent.Value = 100;


        }

        // ---------------------------------------- WINDOWS ----------------------------------------
        #region Events
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            gameProxy.EndGame(currentMatch);
            gameProxy.UnSbuscribeGame();
            this.Close();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gameProxy.SubscribeGame();
            rbChat.AppendText(System.Environment.NewLine + "Room - " + currentMatch.RmNumber.ToString() + " Is Ready!" + System.Environment.NewLine);
            rbChat.AppendText("Player 1: " + currentMatch.Player1.Username + System.Environment.NewLine);
            rbChat.AppendText("Player 2: " + currentMatch.Player2.Username + System.Environment.NewLine);
            rbChat.ScrollToEnd();

            TurnStart();
        }
        private void tbMessage_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tbMessage.GotFocus -= tbMessage_GotFocus;
        }

        #endregion

        #region Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = tbHome.Text + ": " + tbMessage.Text;
            gameProxy.Chat(message);
            tbMessage.Clear();
            tbMessage.Text = "Send your message";
        }
        private void rbFight_Click(object sender, RoutedEventArgs e)
        {
            spNormalAttack.Visibility = Visibility.Visible;
            spSkills.Visibility = Visibility.Visible;
            lbStory.Visibility = Visibility.Collapsed;
        }

        private void rbGiveup_Click(object sender, RoutedEventArgs e)
        {
            //gameProxy.EndGame(currentMatch);
        }

        private void rbTackle_Click(object sender, RoutedEventArgs e)
        {
            // chose opponent
            if (currentMatch.Turn.Username == me.Username)
            {
                MonsterFeastService.Skill temp = new MonsterFeastService.Skill();
                if (home.Username == me.Username)
                {
                    // opponent is home
                    gameProxy.attack(home, opponent, "tackle", pbHome.Value);
                }
                else if(opponent.Username == me.Username)
                {
                    // opponent is opponent
                    gameProxy.attack(opponent, home, "tackle", pbOpponent.Value);
                }
            }
            //gameProxy.attack(me, );
        }

        private void rbEndTurn_Click(object sender, RoutedEventArgs e)
        {
            gameProxy.endTurn(me);
        }

        private void rbSkill1_Click(object sender, RoutedEventArgs e)
        {
            if (home.Username == me.Username)
            {
                // opponent is home
                gameProxy.attack(home, opponent, "SkillA", pbHome.Value);
            }
            else if (opponent.Username == me.Username)
            {
                // opponent is opponent
                gameProxy.attack(opponent, home, "SkillA", pbOpponent.Value);
            }
        }

        private void rbSkillB_Click(object sender, RoutedEventArgs e)
        {
            if (home.Username == me.Username)
            {
                // opponent is home
                gameProxy.attack(home, opponent, "SkillB", pbHome.Value);
            }
            else if (opponent.Username == me.Username)
            {
                // opponent is opponent
                gameProxy.attack(opponent, home, "SkillB", pbOpponent.Value);
            }
        }
        #endregion

        // ---------------------------------------- METHODS ----------------------------------------
        #region Services
        public void TurnStart()
        {
            // Check who's turn is this
            if (currentMatch.Turn.Username == home.Username)
            {
                if (home.Username == me.Username)
                {
                    disableAll();
                    lbStory.Text = "Your Turn";
                    rbFight.IsEnabled = true;
                }
                if(opponent.Username == me.Username)
                {
                    lbStory.Visibility = Visibility.Visible;
                    lbStory.Text = "Waiting For Next Turn";
                    disableAll();
                }
            }
            else if (currentMatch.Turn.Username == opponent.Username)
            {
                if (home.Username == me.Username)
                {
                    lbStory.Text = "Waiting For Next Turn";
                    disableAll();
                }
                if (opponent.Username == me.Username)
                {
                    disableAll();
                    lbStory.Text = "Your Turn";
                    rbFight.IsEnabled = true;
                }
            }
        }

        public void TurnEnded()
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                if (currentMatch.Turn.Username == home.Username)
                {
                    currentMatch.Turn = opponent;
                }
                else if (currentMatch.Turn.Username == opponent.Username)
                {
                    currentMatch.Turn = home;
                }
                else
                {

                }

                TurnStart();
            }));
        }

        public void updateHistoryBox(string message)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                rbChat.AppendText(message + System.Environment.NewLine);
                rbChat.ScrollToEnd();
            }));
        }

        public void updateHealth(double health, MonsterFeastService.Player attacked)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                if (attacked.Username == home.Username)
                {
                    pbHome.Value = health;
                }
                else
                {
                    pbOpponent.Value = health;
                }
            }));
        }
        public void finishedGame(string message)
        {
            Dispatcher.BeginInvoke(new Action(delegate
            {
                rbGiveup.IsEnabled = false;
                rbFight.IsEnabled = false;
                lbStory.Text = "Game Is Finished!";
                gameProxy.EndGame(currentMatch);
            }));
        }
        #endregion

        #region Methods
        public void disableAll()
        {
            spNormalAttack.Visibility = Visibility.Collapsed;
            spSkills.Visibility = Visibility.Collapsed;
            rbFight.IsEnabled = false;
            rbFight.IsChecked = false;
            lbStory.Visibility = Visibility.Visible;
        }
        #endregion


        

        



    }
}
