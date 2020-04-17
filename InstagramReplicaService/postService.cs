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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "postService" in both code and config file together.
    public class postService : IpostService
    {
        private readonly string cs;
        public postService()
        {
            //cs = @"Data Source=(LOCALDB)\MSSqlLocalDb;Initial Catalog=instagramDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

    }
    public void createPost(Post post)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText =
                        "INSERT INTO post (userId,photopath,location,post_text,creation_date,likes) VALUES(@userId,@photopath,@location,@post_text,@creation_date,0)"
                };


                cmd.Parameters.Add(new SqlParameter("@userId", post.userId));
                cmd.Parameters.Add(new SqlParameter("@photopath", post.photopath));
                cmd.Parameters.Add(new SqlParameter("@location", post.location));
                cmd.Parameters.Add(new SqlParameter("@post_text", post.post_text));
                cmd.Parameters.Add(new SqlParameter("@creation_date", post.creation_date));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void deletePost(int postId)
        {
            //throw new NotImplementedException();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from post where postId = @Id";
                SqlParameter paramId = new SqlParameter { ParameterName = "@Id", Value = postId };
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }


        }

        public void updatePost(Post post)
        {
            //throw new NotImplementedException();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE post SET post_text = @post_text,location = @location,photopath = @photopath Where postId = @postId";
                cmd.Parameters.Add(new SqlParameter("@postId", post.postId));
                cmd.Parameters.Add(new SqlParameter("@photopath", post.photopath));
                cmd.Parameters.Add(new SqlParameter("@location", post.location));
                cmd.Parameters.Add(new SqlParameter("@post_text", post.post_text));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Post> fetchPost(int userId)
        {
            List<Post> posts = new List<Post>();
            //throw new NotImplementedException();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from post where userId = @Id";
                SqlParameter paraid = new SqlParameter { ParameterName = "@Id", Value = userId };
                cmd.Parameters.Add(paraid);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Post p = new Post();
                    p.userId = Convert.ToInt32(reader["userId"]);
                    p.postId = Convert.ToInt32(reader["postId"]);
                    p.photopath = reader["photopath"].ToString();
                    p.location = reader["location"].ToString();
                    p.post_text = reader["post_text"].ToString();
                    p.likes = Convert.ToInt32(reader["likes"]);
                    p.creation_date = Convert.ToDateTime(reader["creation_date"]);
                    posts.Add(p);
                }
            }
            return posts;
        }


        public int? incrementLike(int likes,int postId)
        {
            Post p = new Post();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                
                cmd.CommandText = "UPDATE post SET likes = @likes Where postId = @postId";
                cmd.Parameters.Add(new SqlParameter("@postId", postId));
              
                cmd.Parameters.Add(new SqlParameter("@likes",likes + 1));

                cmd.ExecuteNonQuery();
            }
            return likes + 1;
        }

        public int? decrementLike(int likes,int postId)
        {
            Post p = new Post();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
           

                cmd.CommandText = "UPDATE post SET likes = @likes Where postId = @postId";
                cmd.Parameters.Add(new SqlParameter("@postId", postId));

                cmd.Parameters.Add(new SqlParameter("@likes", likes - 1));

                con.Open();
                cmd.ExecuteNonQuery();
            }
            return likes - 1;
        }
    
    }
}
