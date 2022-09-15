using System.Reflection;
using CloudFit.SqlClient.ConsoleApp;
using CloudFit.SqlClient.Database;
using CloudFit.SqlClient.Database.Core;
using CloudFit.SqlClient.Database.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var config = new ConfigurationBuilder()
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
    .AddEnvironmentVariables()
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection");

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(serviceCollection =>
    {
        serviceCollection.AddSingleton<ISqlConnectionFactory>(new SqlConnectionFactory(connectionString));
        serviceCollection.AddSingleton<IRepository, Repository>();
        serviceCollection.AddSingleton<IToDoService, ToDoService>();
        serviceCollection.AddHostedService<Worker>();
    })
    .Build()
    .Run();