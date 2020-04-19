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
    public partial class FollowingComponent : UserControl
    {
        private string _follower;
        [Category("Custom Props")]
        public string Follower
        {
            get { return _follower; }
            set { this._follower = value; label1.Text = value; }
        }

        private int _uid;
        [Category("Custom Props")]
        public int Uid
        {
            get { return this._uid; }
            set { this._uid = value; }
        }
        public FollowingComponent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UFInstaSR.IuserfollowServiceClient client = new UFInstaSR.IuserfollowServiceClient();
                client.unfollowUser(InstaDB.user.userId, Uid);
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
