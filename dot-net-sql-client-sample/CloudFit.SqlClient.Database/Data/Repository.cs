using System.Data;
using CloudFit.SqlClient.Database.Models;
using Dapper;

namespace CloudFit.SqlClient.Database.Data;

public interface IRepository
{
    Task<IEnumerable<ToDoItem>> ToDoItems();
}

public class Repository : IRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public Repository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public Task<IEnumerable<ToDoItem>> ToDoItems()
    {
        return Connection().QueryAsync<ToDoItem>(
            @"
        SELECT [TaskID]
              ,[TaskName]
              ,[AssignedTo]
        FROM [dbo].[ToDoList]");
    }

    private IDbConnection Connection()
    {
        return _connectionFactory.CreateConnection();
    }
}