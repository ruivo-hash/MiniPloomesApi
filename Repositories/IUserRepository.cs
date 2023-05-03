using MiniPloomesApi.Domain;

namespace MiniPloomesApi.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        List<User> GetAll();
    }
}
