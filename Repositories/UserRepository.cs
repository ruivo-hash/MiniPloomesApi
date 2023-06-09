﻿using Microsoft.AspNetCore.Identity;
using MiniPloomesApi.Domain;
using MiniPloomesApi.Endpoints.Clients;
using MiniPloomesApi.Endpoints.Users;
using System.Data.SqlClient;

namespace MiniPloomesApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Create(User user)
        {
            using(SqlConnection conn = new SqlConnection(_config.GetValue<string>("Database:ConnectionString")))
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

        public List<UserResponse> GetAll()
        {
            List<UserResponse> users = new List<UserResponse>();
            using (SqlConnection conn = new SqlConnection(_config.GetValue<string>("Database:ConnectionString")))
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Users", conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int id = reader.GetInt16(0);
                            string name = reader.GetString(1);
                            string email = reader.GetString(2);
                            users.Add(new UserResponse(id, name, email));
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

        public UserResponse GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_config.GetValue<string>("Database:ConnectionString")))
            {
                UserResponse user = null;
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", conn))
                    {
                        command.Parameters.Add(new SqlParameter("Id", id));
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            string name = reader.GetString(1);
                            string email = reader.GetString(2);
                            user = new UserResponse(id, name, email);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return user;
            }
        }
    }
}
