using MiniPloomesApi.Domain;
using MiniPloomesApi.Repositories;

namespace MiniPloomesApi.Endpoints.Users
{
    public class UserPost
    {
        public static string Template => "/users";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(UserRequest request, UserRepository repository)
        {
            var user = new User(request.Name, request.Email);
            repository.Create(user);

            return Results.Ok();
        }
    }
}
