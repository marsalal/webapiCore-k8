using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webApik8.Models;
using webApik8.Services;

namespace webApik8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetTodoList()
        {
            return Ok(_todoService.GetAllItems());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTodo(string id)
        {
            var result = _todoService.GetItem(id);
            if(result == null) return NotFound($"Todo list with {id} not found");

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _todoService.Add(todo);

            return Created($"/{todo.Id}", todo);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateItem([FromBody] Todo todo, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _todoService.Update(todo, id);
            
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteItem(string id)
        {
            var isDeleted = _todoService.Delete(id);
            if(!isDeleted) return NotFound();

            return NoContent();
        }        
    }
}