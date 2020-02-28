using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramReplicaService
{
    public class User
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
        public DateTime creation_date { get; set; }
        public string password { get; set; }
    }
}
