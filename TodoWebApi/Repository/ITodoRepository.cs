using System.Collections.Generic;
using System.Threading.Tasks;
using TodoWebApi.Models;

namespace TodoWebApi.Repository
{
    public interface ITodoRepository
    {
        Task<List<TodoModel>> GetAllTodosAsync();
        Task<int> AddTodoAsync(TodoModel todoModel);
        Task DeleteTodoAsync(int id);
        Task<TodoModel> GetTodoByIdAsync(int bookId);


    }
}
