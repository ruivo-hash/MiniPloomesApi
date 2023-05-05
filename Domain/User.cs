using System.Drawing;

namespace MiniPloomesApi.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Client> Clients { get; set; }

        public User()
        {
        }
        public User(string name, string email)
        {
            Name = name;
            Email = email;
            Clients = new List<Client>();
        }
    }
}
