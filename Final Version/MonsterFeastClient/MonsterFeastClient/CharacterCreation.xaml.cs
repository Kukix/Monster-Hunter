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
using System.Windows.Media.Animation;

namespace MonsterFeastClient
{
    /// <summary>
    /// Interaction logic for CharacterCreation.xaml
    /// </summary>
    public partial class CharacterCreation : Window
    {
        // ---------------------------------------- PROPERTIES ----------------------------------------
        MonsterFeastService.LoginClient loginProxy;
        MonsterFeastService.Player p = Login.Player;
        MonsterFeastService.CharClass charClass;
        MonsterFeastService.Element element;
        
        Storyboard s;
        bool isClassLoaded = false;
        bool isCreateLoaded = false;

        // ---------------------------------------- CONSTRUCTOR ----------------------------------------
        public CharacterCreation()
        {
            this.InitializeComponent();
            loginProxy = new MonsterFeastService.LoginClient();
        }

        // ---------------------------------------- WINDOWS ----------------------------------------
        #region FORMS
        private void closeBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
        private void tbName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= tbName_GotFocus;
        }
        #endregion

        #region BUTTONS
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;

            if (btnWater.IsChecked == true) element = MonsterFeastService.Element.Water;
            if (btnFire.IsChecked == true) element = MonsterFeastService.Element.Fire;
            if (btnAir.IsChecked == true) element = MonsterFeastService.Element.Air;
            if (btnEarth.IsChecked == true) element = MonsterFeastService.Element.Earth;

            if (rbArcher.IsChecked == true) charClass = MonsterFeastService.CharClass.Archer;
            if (rbWarrior.IsChecked == true) charClass = MonsterFeastService.CharClass.Warrior;
            if (rbWizard.IsChecked == true) charClass = MonsterFeastService.CharClass.Wizard;

            loginProxy.createCharacter(p.Id, name, charClass, element);

            MessageBox.Show("Character Successfully Created!");

            this.Close();
        }

        private void btnWater_Click(object sender, RoutedEventArgs e)
        {
            disableElement();
            btnWater.IsChecked = true;


        }

        private void btnFire_Click(object sender, RoutedEventArgs e)
        {
            disableElement();
            btnFire.IsChecked = true;
        }

        private void btnAir_Click(object sender, RoutedEventArgs e)
        {
            disableElement();
            btnAir.IsChecked = true;
        }

        private void btnEarth_Click(object sender, RoutedEventArgs e)
        {
            disableElement();
            btnEarth.IsChecked = true;
        }

        private void rbArcher_Click(object sender, RoutedEventArgs e)
        {
            if (!isCreateLoaded)
            {
                s = (Storyboard)FindResource("LoadCreateChar");
                s.Begin();
                isCreateLoaded = true;
            }
        }
        #endregion

        // ---------------------------------------- METHODS ----------------------------------------
        public void disableElement()
        {
            btnWater.IsChecked = false;
            btnFire.IsChecked = false;
            btnEarth.IsChecked = false;
            btnAir.IsChecked = false;

            if (!isClassLoaded)
            {
                s = (Storyboard)FindResource("LoadClass");
                s.Begin();
                isClassLoaded = true;
            }
        }

    }
}
