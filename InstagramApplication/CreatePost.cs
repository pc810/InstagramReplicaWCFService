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
    public partial class CreatePost : UserControl
    {
        public CreatePost()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string description = textBox1.Text;
                string link = textBox2.Text;
                PInstaSR.Post post = new PInstaSR.Post();
                post.userId = InstaDB.user.userId;
                post.photopath = link;
                post.location = textBox3.Text;
                post.creation_date = DateTime.Now;
                post.post_text = description;
                post.likes = 0;
                PInstaSR.IpostServiceClient client = new PInstaSR.IpostServiceClient();
                client.createPost(post);
                label5.Text = "Posted your post";
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
    }
}
