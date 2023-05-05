using Microsoft.AspNetCore.Identity;
using MiniPloomesApi.Domain;
using MiniPloomesApi.Endpoints.Clients;
using MiniPloomesApi.Endpoints.Users;
using System.Data.SqlClient;

namespace MiniPloomesApi.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _config;

        public ClientRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Create(Client client)
        {
            using(SqlConnection conn = new SqlConnection(_config.GetValue<string>("Database:ConnectionString")))
            {
                conn.Open();
                try
                {
                    using(SqlCommand command = new SqlCommand("INSERT INTO Clients VALUES (@Name, @CreationDate, @UserId)", conn))
                    {
                        command.Parameters.Add(new SqlParameter("Name", client.Name));
                        command.Parameters.Add(new SqlParameter("CreationDate", client.CreationDate));
                        command.Parameters.Add(new SqlParameter("UserId", client.UserId));
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public List<ClientResponse> GetAll()
        {
            List<ClientResponse> clients = new List<ClientResponse>();
            using (SqlConnection conn = new SqlConnection(_config.GetValue<string>("Database:ConnectionString")))
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Clients", conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int id = reader.GetInt16(0);
                            string name = reader.GetString(1);
                            DateTime creation = reader.GetDateTime(2);
                            int user = reader.GetInt16(3);
                            clients.Add(new ClientResponse(id, name, creation, user));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return clients;
            }
        }

        public List<ClientResponse> GetByUser(int userId)
        {
            List<ClientResponse> clients = new List<ClientResponse>();
            using (SqlConnection conn = new SqlConnection(_config.GetValue<string>("Database:ConnectionString")))
            {
                conn.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Clients WHERE UserId = @UserId", conn))
                    {
                        command.Parameters.Add(new SqlParameter("UserId", userId));
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int id = reader.GetInt16(0);
                            string name = reader.GetString(1);
                            DateTime creation = reader.GetDateTime(2);
                            int user = reader.GetInt16(3);
                            clients.Add(new ClientResponse(id, name, creation, user));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return clients;
            }
        }
    }
}
