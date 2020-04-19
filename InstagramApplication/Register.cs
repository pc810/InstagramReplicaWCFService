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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = NameInput.Text;
                string email = EmailInput.Text;
                string pass = PasswordInput.Text;
                string repass = ConfirmPasswordInput.Text;
                UInstaSR.User user = new UInstaSR.User();
                user.username = username;
                user.password = pass;
                user.email = email;
                user.dob = new DateTime(dateTimePicker1.Value.Ticks);
                user.creation_date = DateTime.Now;
                UInstaSR.UserServiceClient client = new UInstaSR.UserServiceClient();
                client.CreateUser(user);
                this.Visible = false;
                Form f = new Login();
                f.Visible = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
