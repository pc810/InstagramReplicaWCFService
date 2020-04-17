using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace InstagramReplicaService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "commentService" in both code and config file together.
    public class commentService : IcommentService
    {
        private readonly string cs;
        public commentService()
        {
            //cs = @"Data Source=(LOCALDB)\MSSqlLocalDb;Initial Catalog=instagramDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

    }
    public void createComment(Comment comment)
        { 
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO comment (userId,postId,comment,creation_date) VALUES(@userId,@postId,@comment,@creation_date)";

                SqlParameter parauserid = new SqlParameter {ParameterName = "@userId", Value = comment.userId};
                cmd.Parameters.Add(parauserid);

                SqlParameter parapostid = new SqlParameter {ParameterName = "@postId", Value = comment.postId};
                cmd.Parameters.Add(parapostid);

                SqlParameter paracomment = new SqlParameter {ParameterName = "@comment", Value = comment.comment};
                cmd.Parameters.Add(paracomment);

                SqlParameter paracreationtime = new SqlParameter
                {
                    ParameterName = "@creation_date", Value = comment.creation_date
                };
                cmd.Parameters.Add(paracreationtime);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void deleteComment(int commentId)
        {
            //throw new NotImplementedException();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from comment where commentId = @Id";
                SqlParameter paramId = new SqlParameter {ParameterName = "@Id", Value = commentId};
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }


        }

        public void updateComment(Comment comment)
        {
            //throw new NotImplementedException();
            
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE comment SET comment = @comment Where commentId = @commentId";
                SqlParameter paracommentid = new SqlParameter { ParameterName = "@commentId", Value = comment.commentId };
                cmd.Parameters.Add(paracommentid);

                SqlParameter paracomment = new SqlParameter { ParameterName = "@comment", Value = comment.comment };
                cmd.Parameters.Add(paracomment);
                

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Comment> fetchComment(int postId)
        {
            List<Comment> comments = new List<Comment>();
            //throw new NotImplementedException();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from comment where postId = @Id";
                SqlParameter paraid = new SqlParameter {ParameterName = "@Id", Value = postId};
                cmd.Parameters.Add(paraid);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Comment c = new Comment();
                    c.commentId = Convert.ToInt32(reader["commentId"]);
                    c.userId = Convert.ToInt32(reader["userId"]);
                    c.postId = Convert.ToInt32(reader["postId"]);

                    c.comment = reader["comment"].ToString();
                    c.creation_date = Convert.ToDateTime(reader["creation_date"]);
                    comments.Add(c);
                }
            }
            return comments;
        }
    }
}
