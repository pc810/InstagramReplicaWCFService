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
    public partial class CommentComponent : UserControl
    {
        private int _cid;
        [Category("Custom Props")]
        public int Cid
        {
            get { return _cid; }
            set { this._cid = value; }

        }

        private string _commentText;
        [Category("Custom Props")]
        public string CommentText
        {
            get { return _commentText; }
            set { this._commentText = value; label2.Text = value; }
        }



        private string _user;
        [Category("Custom Props")]
        public string Username
        {
            get { return _user; }
            set { this._user = value; label1.Text = value; }
        }
        public CommentComponent()
        {
            InitializeComponent();          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("clicked delete");
            try
            {
                CInstaSR.IcommentServiceClient client = new CInstaSR.IcommentServiceClient();
                client.deleteComment(Cid);
                this.Visible = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                    
            }
        }

        private void CommentComponent_Load(object sender, EventArgs e)
        {
            
            if (!this.Username.Equals(InstaDB.user.username))
                button1.Visible = false;            
        }
    }
}
