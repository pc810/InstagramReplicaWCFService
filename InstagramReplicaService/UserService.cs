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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
        //public string cs = @"Data Source=(LOCALDB)\MSSqlLocalDb;Initial Catalog=instagramDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;        
        public void CreateUser(User user)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                //INSERT INTO comment (userId,postId,comment,creation_date) VALUES(@userId,@postId,@comment,@creation_date
                command.CommandText = "INSERT INTO [dbo].[user] (username,email,dob,creation_date,password) VALUES(@name,@email,@dob,@creation_date,@password)";
                command.Parameters.Add(new SqlParameter("@name", user.username));
                command.Parameters.Add(new SqlParameter("@email", user.email));
                command.Parameters.Add(new SqlParameter("@dob", user.dob));
                command.Parameters.Add(new SqlParameter("@creation_date", user.creation_date));
                command.Parameters.Add(new SqlParameter("@password", user.password));

                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int userId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "delete from [dbo].[user] where userId=@Id";
                command.Parameters.Add(new SqlParameter("@Id", userId));
            
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public User getUser(int userId)
        {
            User user = new User();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "select * from [dbo].[user] where userId = @id";
                command.Parameters.Add(new SqlParameter("@id", userId));
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.userId = Convert.ToInt32(reader["userId"]);
                    user.username = reader["username"].ToString();
                    user.email = reader["email"].ToString();
                    user.dob = Convert.ToDateTime(reader["dob"]);
                    user.creation_date = Convert.ToDateTime(reader["creation_date"]);
                    user.password = reader["password"].ToString();
                }
            }
            return user;
        }

        public User getUserByEmail(string email)
        {
            User user = new User();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "select * from [dbo].[user] where email = @email";
                command.Parameters.Add(new SqlParameter("@email", email));
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.userId = Convert.ToInt32(reader["userId"]);
                    user.username = reader["username"].ToString();
                    user.email = reader["email"].ToString();
                    user.dob = Convert.ToDateTime(reader["dob"]);
                    user.creation_date = Convert.ToDateTime(reader["creation_date"]);
                    user.password = reader["password"].ToString();
                }
            }
            return user;
        }

        public int getUserId(string email)
        {
            int userId=0;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "select userId from [dbo].[user] where email = @email";
                command.Parameters.Add(new SqlParameter("@email", email));
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userId = Convert.ToInt32(reader["userId"]);   
                }
            }
            return userId;
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "update [dbo].[user] set username=@name , email=@email , dob=@dob , creation_date=@creation_date , password=@password";
                command.Parameters.Add(new SqlParameter("@name", user.username));
                command.Parameters.Add(new SqlParameter("@email", user.email));
                command.Parameters.Add(new SqlParameter("@dob", user.dob));
                command.Parameters.Add(new SqlParameter("@creation_date", user.creation_date));
                command.Parameters.Add(new SqlParameter("@password", user.password));

                con.Open();
                command.ExecuteNonQuery();
            }
            
        }
        public List<User> getUserWith(string username)
        {
            List<User> userlist = new List<User>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con;
                command.CommandText = "select * from [dbo].[user] where username LIKE @username";
                command.Parameters.Add(new SqlParameter("@username", "%" + username + "%"));
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.userId = Convert.ToInt32(reader["userId"]);
                    user.username = reader["username"].ToString();
                    user.email = reader["email"].ToString();
                    user.dob = Convert.ToDateTime(reader["dob"]);
                    user.creation_date = Convert.ToDateTime(reader["creation_date"]);
                    user.password = reader["password"].ToString();
                    userlist.Add(user);
                }
            }
            return userlist;
        }
    }
}
