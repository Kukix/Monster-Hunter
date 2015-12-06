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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.ComponentModel;


namespace MonsterFeastClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, MonsterFeastService.ILobbyCallback 
    {

        MonsterFeastService.LobbyClient lobbyProxy;
        MonsterFeastService.Player player;
        List<string> players;

        public MainWindow()
        {
            InitializeComponent();
            lobbyProxy = new MonsterFeastService.LobbyClient(new InstanceContext(this));
            player = new MonsterFeastService.Player();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbName.Text;
            string password = tbPass.Text;
            player = lobbyProxy.Login(username, password);

            MessageBox.Show(player.Wins.ToString());
        }

        public void updateChatBox(string message)
        {

        }
    }
}
