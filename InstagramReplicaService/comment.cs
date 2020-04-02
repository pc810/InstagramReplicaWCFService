using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramReplicaService
{
    public class Comment
    {
        public int commentId { get; set; }
        public int userId { get; set; }
        public int postId { get; set; }
        public string comment { get; set; }
        public DateTime creation_date { get; set; }
    }
}
