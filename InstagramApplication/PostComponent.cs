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
    public partial class PostComponent : UserControl
    {
        private int _pid;
        [Category("Custom Props")]
        public int Pid
        {
            get { return _pid; }
            set { this._pid = value; }

        }
        private string _title;
        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { this._title = value; label1.Text = value; }
        }




        private string _by;
        [Category("Custom Props")]
        public string By
        {
            get { return _by; }
            set { this._by = value; label3.Text = value; }
        }



        private Image _post_image;
        [Category("Custom Props")]
        public Image PostImage
        {
            get { return _post_image; }
            set { this._post_image = value; pictureBox1.Image = value; }
        }

        private int? _likes;
        [Category("Custom Props")]
        public int? Likes
        {
            get { return _likes; }
            set { this._likes = value; label2.Text = value + " Likes"; }
        }
        public PostComponent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                PInstaSR.IpostServiceClient client = new PInstaSR.IpostServiceClient();
                client.incrementLike(this.Likes.GetValueOrDefault(0), this.Pid);
                this.Likes++;
                label2.Text = this.Likes + "Likes";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Comments(this);
            f.Visible = true;
        }
    }
}
