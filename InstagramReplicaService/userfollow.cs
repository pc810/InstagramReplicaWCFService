using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramReplicaService
{
    public class UserFollow
    {
        // userId1 is followed by userId2
        public int userId1 { get; set; } 
        public int userId2 { get; set; }
    }
}
