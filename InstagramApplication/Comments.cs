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
    public partial class Comments : Form
    {
        private List<CommentComponent> subcomlist = new List<CommentComponent>();
        private PostComponent comp;
        private List<CInstaSR.Comment> commentlist;
        public Comments(PostComponent comp)
        {
            this.comp = comp;
            InitializeComponent();
        }

        private void Comments_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = comp.PostImage;
            label1.Text = comp.Title;
            try
            {
                flowLayoutPanel1.Controls.Clear();
                UInstaSR.UserServiceClient uclient = new UInstaSR.UserServiceClient();
                CInstaSR.IcommentServiceClient client = new CInstaSR.IcommentServiceClient();
                this.commentlist = client.fetchComment(comp.Pid).OrderByDescending(c => c.creation_date).ToList();
                foreach (CInstaSR.Comment comment in commentlist)
                {
                    CommentComponent c = new CommentComponent();
                    c.CommentText = comment.comment;

                    c.Username = uclient.getUser(comment.userId).username;
                    subcomlist.Add(c);
                    flowLayoutPanel1.Controls.Add(c);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CInstaSR.IcommentServiceClient client = new CInstaSR.IcommentServiceClient();
                CInstaSR.Comment comment = new CInstaSR.Comment();
                comment.userId = InstaDB.user.userId;
                comment.postId = comp.Pid;
                comment.comment = textBox1.Text;
                comment.creation_date = DateTime.Now;
                client.createComment(comment);
                CommentComponent c = new CommentComponent();
                c.CommentText = comment.comment;
                c.Username = InstaDB.user.username;
                subcomlist.Add(c);
                textBox1.Text = "";
                flowLayoutPanel1.Controls.Add(c);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Comments_Load_1(object sender, EventArgs e)
        {
            Comments_Load(sender, e);
        }
    }
}
