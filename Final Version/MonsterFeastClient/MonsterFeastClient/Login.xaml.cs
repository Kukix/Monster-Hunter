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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        // ---------------------------------------- PROPERTIES ----------------------------------------
        MonsterFeastService.LoginClient loginProxy;
        private static MonsterFeastService.Player player;
        public static MonsterFeastService.Player Player
        {
            get { return player; }
            set { player = value; }
        }

        // ---------------------------------------- CONSTRUCTOR ----------------------------------------
        public Login()
        {
            InitializeComponent();

            loginProxy = new MonsterFeastService.LoginClient();
            player = new MonsterFeastService.Player();

            btnLogin.Content = "Login";
            registerBtn.Content = "Register";

        }

        // ---------------------------------------- WINDOWS ----------------------------------------
        #region FORMS
        private void titleRect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
        private void passwordBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            PasswordBox pb = (PasswordBox)sender;
            pb.Password = string.Empty;
            pb.GotFocus -= passwordBox_GotFocus;
        }
        private void userBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= userBox_GotFocus;
        }
        #endregion

        // ---------------------------------------- BUTTONS ----------------------------------------
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = userBox.Text;
            string password = passwordBox.Password;

            if (btnLogin.Content == "Login")
            {
                player = loginProxy.Login(username, password);

                if (player != null)
                {
                    if (loginProxy.hasChar(player.Username))
                    {
                        loginProxy.addToList(player);
                        Lobby lobbyForm = new Lobby();
                        this.Visibility = Visibility.Collapsed;
                        lobbyForm.ShowDialog();
                        this.Visibility = Visibility.Visible;
                   
                    }
                    else
                    {
                        CharacterCreation createform = new CharacterCreation();
                        this.Visibility = Visibility.Collapsed;
                        createform.ShowDialog();
                        this.Visibility = Visibility.Visible;

                    }
                }
                else
                {
                    MessageBox.Show("Can't Login");
                }
            }
            else
            {
                if (loginProxy.isRegistered(username) == true)
                {
                    MessageBox.Show("Username already exists!");
                }
                else
                {
                    loginProxy.Register(username, password);
                    MessageBox.Show("Successfully Registered!");
                    //loginProxy.addToList(player);
                    //Lobby lobbyForm = new Lobby();
                    //this.Hide();
                }
            }
        }
        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (registerBtn.Content.ToString() == "Register")
            {
                btnLogin.Content = "Register";
                registerBtn.Content = "Login";
            }
            else
            {
                btnLogin.Content = "Login";
                registerBtn.Content = "Register";
            }
        }
    }
}
