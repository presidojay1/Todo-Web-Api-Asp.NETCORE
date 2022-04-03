using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWebApi.Models;
using TodoWebApi.Repository;

namespace TodoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllTodo()
        {
            var todos = await _todoRepository.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddTodo([FromBody]TodoModel todoModel)
        {
            var id = await _todoRepository.AddTodoAsync(todoModel);
            return CreatedAtAction(nameof(GetAllTodo), new { id=id, controller = "Todo" }, id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] int id)
        {
          await _todoRepository.DeleteTodoAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById([FromRoute] int id)
        {
            try
            {
                var todo = await _todoRepository.GetTodoByIdAsync(id);
                if (todo != null)
                {
                    return Ok(todo);
                }
            }
            
            catch (Exception ex)
            {

            }
            
            
        }
    }
}
