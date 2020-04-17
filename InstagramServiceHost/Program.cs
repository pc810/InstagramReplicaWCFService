using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace InstagramServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(InstagramReplicaService.UserService)))
            {
                host.Open();
                Console.WriteLine("User service started:" + DateTime.Now.ToString());
            }

            using (ServiceHost host = new ServiceHost(typeof(InstagramReplicaService.postService)))
            {
                host.Open();
                Console.WriteLine("Post service started:" + DateTime.Now.ToString());
            }

            using (ServiceHost host = new ServiceHost(typeof(InstagramReplicaService.commentService)))
            {
                host.Open();
                Console.WriteLine("Comment service started:" + DateTime.Now.ToString());
            }

            using (ServiceHost host = new ServiceHost(typeof(InstagramReplicaService.userfollowService)))
            {
                host.Open();
                Console.WriteLine("User follow service started:" + DateTime.Now.ToString());
            }

            Console.ReadLine();
        }
    }
}
