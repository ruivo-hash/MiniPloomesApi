using MiniPloomesApi.Endpoints.Users;
using MiniPloomesApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<UserRepository>();

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

app.Run();
