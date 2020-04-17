using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InstagramReplicaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "userfollowService" in both code and config file together.
    public class userfollowService : IuserfollowService
    {
        private readonly string cs;
        public userfollowService()
        {
            //cs = @"Data Source=(LOCALDB)\MSSqlLocalDb;Initial Catalog=instagramDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        }
    public void followUser(int userId1, int userId2)
        {
            //throw new NotImplementedException();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO userfollow (userId1,userId2) VALUES(@userId1,@userId2)";

                SqlParameter parauserid1 = new SqlParameter { ParameterName = "@userId1", Value = userId1 };
                cmd.Parameters.Add(parauserid1);

                SqlParameter parauserid2 = new SqlParameter { ParameterName = "@userId2", Value = userId2 };
                cmd.Parameters.Add(parauserid2);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void unfollowUser(int userId1, int userId2)
        {
            //throw new NotImplementedException();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Delete from userfollow where userId1 = @userId1 and userId2 = @userId2";
                SqlParameter paramId1 = new SqlParameter { ParameterName = "@userId1", Value = userId1 };
                cmd.Parameters.Add(paramId1);
                SqlParameter paramId2 = new SqlParameter { ParameterName = "@userId2", Value = userId2 };
                cmd.Parameters.Add(paramId2);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
