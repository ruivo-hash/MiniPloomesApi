using Microsoft.AspNetCore.Identity;
using MiniPloomesApi.Domain;
using System.Data.SqlClient;

namespace MiniPloomesApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        string _connectionString = "Data Source=localhost;Initial Catalog=MiniPloomesApiDb;User Id=sa;Password=Ru1v073198462$$!;";
        public void Create(User user)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                try
                {
                    using(SqlCommand command = new SqlCommand("INSERT INTO Users VALUES (@Name, @Email)", conn))
                    {
                        command.Parameters.Add(new SqlParameter("Name", user.Name));
                        command.Parameters.Add(new SqlParameter("Email", user.Email));
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Users", conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string email = reader.GetString(1);
                            users.Add(new User(name, email));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return users;
            }
        }
    }
}
