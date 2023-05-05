using MiniPloomesApi.Domain;
using MiniPloomesApi.Endpoints.Clients;
using MiniPloomesApi.Endpoints.Users;

namespace MiniPloomesApi.Repositories
{
    public interface IClientRepository
    {
        void Create(Client client);
        List<ClientResponse> GetAll();
        List<ClientResponse> GetByUser(int userId);
    }
}
