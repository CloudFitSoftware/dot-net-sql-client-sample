using CloudFit.SqlClient.Database.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CloudFit.SqlClient.ConsoleApp;

internal class Worker : IHostedService
{
    private readonly IHostApplicationLifetime _host;
    private readonly ILogger<Worker> _logger;
    private readonly IToDoService _toDoService;

    public Worker(IHostApplicationLifetime host, IToDoService toDoService, ILogger<Worker> logger)
    {
        _host = host;
        _toDoService = toDoService;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Worker started.");

        await DoTheWork();

        _host.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Worker stopped.");
        return Task.CompletedTask;
    }

    private async Task DoTheWork()
    {
        void DrawHorizontalLine()
        {
            Console.WriteLine("====================================================================================");
        }

        DrawHorizontalLine();
        DrawHorizontalLine();
        Console.WriteLine("All \"To do \" items:");
        var items = await _toDoService.ToDoItems();
        foreach (var item in items) Console.WriteLine(item.ToString());
        DrawHorizontalLine();
        DrawHorizontalLine();
    }
}