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
    public partial class Registration : Form
    {
        MonsterFeastService.LoginClient loginProxy;
        public Registration()
        {
            InitializeComponent();
            loginProxy = new MonsterFeastService.LoginClient();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string repeat = textBox3.Text;
            if (loginProxy.isRegistered(username) == true) 
            {
                MessageBox.Show("Username already exists,please choose another");
            }
            else if (password != repeat)
            {
                MessageBox.Show("Passwords do not match, please try again");
                textBox3.Clear();
            }
            else
            {
                loginProxy.Register(username,password);
                MessageBox.Show("Congradulations you've been succesfully registered");
                this.Hide();
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
