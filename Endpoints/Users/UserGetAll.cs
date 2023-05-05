using MiniPloomesApi.Repositories;

namespace MiniPloomesApi.Endpoints.Users
{
    public class UserGetAll
    {
        public static string Template => "/users";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(UserRepository repository)
        {
            var users = repository.GetAll();

            return Results.Ok(users);
        }
    }
}
