using MiniPloomesApi.Domain;
using MiniPloomesApi.Endpoints.Users;

namespace MiniPloomesApi.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        List<UserResponse> GetAll();
        UserResponse GetById(int id);
    }
}
