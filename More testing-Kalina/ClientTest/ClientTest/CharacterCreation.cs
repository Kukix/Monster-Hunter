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
    public partial class CharacterCreation : Form
    {
        MonsterFeastService.LoginClient loginProxy;
        MonsterFeastService.Player p = Login.Player;
        MonsterFeastService.CharClass charClass;
        MonsterFeastService.Element element;
        public CharacterCreation()
        {
            InitializeComponent();
            loginProxy = new MonsterFeastService.LoginClient();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = tbCharacterName.Text;
            if (rbWater.Checked) element = MonsterFeastService.Element.Water;
            if (rbFire.Checked) element = MonsterFeastService.Element.Fire;
            if (rbAir.Checked) element = MonsterFeastService.Element.Air;
            if (rbEarth.Checked) element = MonsterFeastService.Element.Earth;

            if (rbWarrior.Checked) charClass = MonsterFeastService.CharClass.Warrior;
            if (rbWizard.Checked) charClass = MonsterFeastService.CharClass.Wizard;
            if (rbArcher.Checked) charClass = MonsterFeastService.CharClass.Archer;

            loginProxy.createCharacter(p.Id, name, charClass, element);
        }

        private void CharacterCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login.ActiveForm.Show();
        }

        private void CharacterCreation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login.ActiveForm.Show();
        }

        private void CharacterCreation_Load(object sender, EventArgs e)
        {

        }
    }
}
