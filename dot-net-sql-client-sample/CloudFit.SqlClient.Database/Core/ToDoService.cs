using CloudFit.SqlClient.Database.Data;
using CloudFit.SqlClient.Database.Models;

namespace CloudFit.SqlClient.Database.Core;

public interface IToDoService
{
    Task<IEnumerable<ToDoItem>> ToDoItems();
}

public class ToDoService : IToDoService
{
    private readonly IRepository _repository;

    public ToDoService(IRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ToDoItem>> ToDoItems()
    {
        return _repository.ToDoItems();
    }
}