using MiniPloomesApi.Domain;
using MiniPloomesApi.Repositories;

namespace MiniPloomesApi.Endpoints.Clients
{
    public class ClientPost
    {
        public static string Template => "/clients";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ClientRequest request, ClientRepository clientRepository, UserRepository userRepository)
        {
            var user = userRepository.GetById(request.UserId);
            if (user == null)
                return Results.BadRequest("Usuário não encontrado na base de dados");

            var client = new Client(request.Name, request.UserId);
            clientRepository.Create(client);

            return Results.Ok();
        }
    }
}
