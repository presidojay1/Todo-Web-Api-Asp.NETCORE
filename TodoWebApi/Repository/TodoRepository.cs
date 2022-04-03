using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWebApi.Data;
using TodoWebApi.Models;

namespace TodoWebApi.Repository
{
    public class TodoRepository : ITodoRepository

    {
        private readonly WorkContext _context;
        public TodoRepository(WorkContext context)
        {
            _context = context;
        }
        public async Task<List<TodoModel>> GetAllTodosAsync()
        {
            var todos = await _context.TodoTable.Select(x => new TodoModel()
            {
                Id = x.Id,
                Title = x.Title,
                Completed = x.Completed,
                Name = x.Name,
                Description = x.Description

            }).ToListAsync();

            return todos;
        }

        public async Task<int> AddTodoAsync(TodoModel todoModel)
        {
            var todo = new Todo()
            {
                Title = todoModel.Title,
                Completed = todoModel.Completed,
                Name = todoModel.Name,
                Description = todoModel.Description
            };
            _context.TodoTable.Add(todo);
            await _context.SaveChangesAsync();
            return todo.Id;

        }
        public async Task DeleteTodoAsync(int Todoid)
        {
            var todo = new Todo() { Id = Todoid };
            _context.TodoTable.Remove(todo);
            await _context.SaveChangesAsync();
            
        }
        public async Task<TodoModel> GetTodoByIdAsync(int bookId)
        {
            var todo = await _context.TodoTable.Where(x => x.Id == bookId).Select(x => new TodoModel
            {
                Id = x.Id,
                Title = x.Title,
                Completed = x.Completed,
                Name = x.Name,
                Description = x.Description

            }).FirstOrDefaultAsync();

            return todo;
        }
    }
}