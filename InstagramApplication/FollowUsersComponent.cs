using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace InstagramApplication
{
    public partial class FollowUsersComponent : UserControl
    {
        public FollowUsersComponent()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            try
            {
                UInstaSR.UserServiceClient client = new UInstaSR.UserServiceClient();
                List<UInstaSR.User> users = client.getUserWith(name).ToList();
                Dictionary<int, string> dUsers = new Dictionary<int, string>();
                foreach (UInstaSR.User u in users)
                {
                    dUsers.Add(u.userId, u.username);
                }
                listBox1.DataSource = new BindingSource(dUsers, null);
                listBox1.ValueMember = "Key";
                listBox1.DisplayMember = "Value";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(listBox1.SelectedValue);
            try
            {
                UFInstaSR.IuserfollowServiceClient client = new UFInstaSR.IuserfollowServiceClient();
                client.followUser(InstaDB.user.userId, (int)listBox1.SelectedValue);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
