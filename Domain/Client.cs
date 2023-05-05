namespace MiniPloomesApi.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }

        public Client()
        {
        }

        public Client(string name, int userId)
        {
            Name = name;
            CreationDate = DateTime.Now;
            UserId = userId;
        }
    }
}
