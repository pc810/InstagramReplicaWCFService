using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramReplicaService
{
    public class Post
    {
        public int postId { get; set; }
        public int userId { get; set; }
        public string photopath { get; set; }
        public string location { get; set; }
        public DateTime creation_date { get; set; }
        public string post_text { get; set; }
        public int? likes { get; set; }
    }
}
