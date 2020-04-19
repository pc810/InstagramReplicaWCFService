using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f = new Register();
            f.Show();
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string email = textBox1.Text;
                string pass = textBox2.Text;
                UInstaSR.UserServiceClient client = new UInstaSR.UserServiceClient();
                UInstaSR.User user = client.getUserByEmail(email);
                if (user.password.Equals(pass))
                {
                    InstaDB.loggedIn = true;
                    InstaDB.user = user;
                    Form f = new Home();
                    f.Show();
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
