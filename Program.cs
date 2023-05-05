using MiniPloomesApi.Endpoints.Clients;
using MiniPloomesApi.Endpoints.Users;
using MiniPloomesApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ClientRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapMethods(UserPost.Template, UserPost.Methods, UserPost.Action);
app.MapMethods(UserGetAll.Template, UserGetAll.Methods, UserGetAll.Action);

app.MapMethods(ClientPost.Template, ClientPost.Methods, ClientPost.Action);
app.MapMethods(ClientGetAll.Template, ClientGetAll.Methods, ClientGetAll.Action);
app.MapMethods(ClientGetByUserId.Template, ClientGetByUserId.Methods, ClientGetByUserId.Action);

app.Run();
