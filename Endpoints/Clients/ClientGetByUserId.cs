using Microsoft.AspNetCore.Mvc;
using MiniPloomesApi.Repositories;

namespace MiniPloomesApi.Endpoints.Clients
{
    public class ClientGetByUserId
    {
        public static string Template => "/clients/{id}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] int id, ClientRepository repository)
        {
            var userClients = repository.GetByUser(id);

            return Results.Ok(userClients);
        }
    }
}
