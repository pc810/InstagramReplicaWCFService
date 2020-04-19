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
    public partial class Home : Form
    {
        private List<PInstaSR.Post> postList;
        private List<PostComponent> comps;
        private List<UInstaSR.User> followers;
        private List<FollowingComponent> fcomp;

        private void fetchFollowers()
        {
            //for follower list
            followers = new List<UInstaSR.User>();
            fcomp = new List<FollowingComponent>();
            try
            {
                UFInstaSR.IuserfollowServiceClient ufclient = new UFInstaSR.IuserfollowServiceClient();
                int[] idlist = ufclient.getFollowerList(InstaDB.user.userId);
                UInstaSR.UserServiceClient uclient = new UInstaSR.UserServiceClient();
                foreach (int id in idlist)
                {
                    UInstaSR.User u = uclient.getUser(id);
                    this.followers.Add(u);
                    FollowingComponent comp = new FollowingComponent();
                    comp.Follower = u.username;
                    comp.Uid = u.userId;
                    fcomp.Add(comp);
                }
                InstaDB.followers = this.followers;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void fetchPosts()
        {
            //for post
            comps = new List<PostComponent>();
            postList = new List<PInstaSR.Post>();
            try
            {
                PInstaSR.IpostServiceClient client = new PInstaSR.IpostServiceClient();
                PInstaSR.Post[] postlist = null;

                foreach (UInstaSR.User u in this.followers)
                {
                    postlist = client.fetchPost(u.userId);
                    foreach (var post in postlist)
                    {
                        postList.Add((PInstaSR.Post)post);
                    }
                }
                Debug.WriteLine(postList.Count);
                List<PInstaSR.Post> temp = this.postList.OrderByDescending(p => p.creation_date).ToList();
                this.postList = temp;
                foreach (var post in postList)
                {
                    PostComponent comp = new PostComponent();

                    Debug.WriteLine(post.post_text.ToString());
                    System.Drawing.Image image = InstaDB.DownloadImageFromUrl(post.photopath.ToString().Trim());
                    comp.Title = post.post_text.ToString();
                    comp.PostImage = image;
                    comp.Likes = post.likes;
                    comp.Pid = post.postId;
                    comp.By = followers.Find(u => u.userId == post.userId).username;
                    Debug.WriteLine(post.userId + "  " + comp.By);
                    comps.Add(comp);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (InstaDB.loggedIn)
            {
                flowLayoutPanel2.Controls.Clear();
                label2.Text = "Hello  " + InstaDB.user.username;
                fetchFollowers();
                fetchPosts();
                foreach (var comp in comps)
                {
                    flowLayoutPanel2.Controls.Add(comp);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Controls.Add(new CreatePost());
            fetchFollowers();
            fetchPosts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            foreach (var comp in comps)
            {
                flowLayoutPanel2.Controls.Add(comp);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            for (int i = 0; i < fcomp.Count; i++)
            {
                Debug.WriteLine(fcomp[i].Follower);
                flowLayoutPanel2.Controls.Add(fcomp[i]);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Controls.Add(new FollowUsersComponent());
            fetchFollowers();
            fetchPosts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Login();
            f.Show();
            this.Close();
        }
    }
}
