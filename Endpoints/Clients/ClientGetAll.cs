using MiniPloomesApi.Domain;
using MiniPloomesApi.Repositories;

namespace MiniPloomesApi.Endpoints.Clients
{
    public class ClientGetAll
    {
        public static string Template => "/clients";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(ClientRepository repository)
        {
            var clients = repository.GetAll();

            return Results.Ok(clients);
        }
    }
}
