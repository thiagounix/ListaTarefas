using ListaTarefas.Configurations;
using MongoDB.Driver;
using ListaTarefas.Application.Services;
using ListaTarefa.Domain.Interfaces.Repository;
using ListaTarefas.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mongoDbSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();

builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    return new MongoClient(mongoDbSettings.ConnectionString);
});

builder.Services.AddScoped(serviceProvider =>
{
    var client = serviceProvider.GetRequiredService<IMongoClient>();
    var database = client.GetDatabase(mongoDbSettings.DatabaseName);
    return database;
});
builder.Services.AddScoped<IListaTarefasRepository, ListaTarefasRepository>();
builder.Services.AddScoped<ListaTarefasService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
