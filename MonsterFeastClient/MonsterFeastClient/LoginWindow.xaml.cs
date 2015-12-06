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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, MonsterFeastService.ILobbyCallback 
    {
        MonsterFeastService.LobbyClient lobbyProxy;
        MonsterFeastService.Player player;

        public LoginWindow()
        {
            InitializeComponent();
            //UCLogin loginControl = new UCLogin();
            //controlPage.Content = loginControl;
            lobbyProxy = new MonsterFeastService.LobbyClient(new InstanceContext(this));
            player = new MonsterFeastService.Player();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            player = lobbyProxy.Login(username, password);

            MessageBox.Show(player.Wins.ToString());

            if (player != null)
            {
                if (player.Character != null)
                {
                    LobbyWindow temp = new LobbyWindow(player);
                    temp.Show();
                    this.Close();
                }
                else
                {
                    CharWindow temp = new CharWindow();
                    temp.Show();
                    this.Close();
                }
            }
        }

        private void tbLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            registerPanel.Visibility = Visibility.Collapsed;
            loginPanel.Visibility = Visibility.Visible;
        }

        private void tbRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            registerPanel.Visibility = Visibility.Visible;
            loginPanel.Visibility = Visibility.Collapsed;
        }

        public void updateChatBox(string message)
        {

        }
    }
}
