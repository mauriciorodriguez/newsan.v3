using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private TodoRepository _todoRepository;
        public TodoController(TodoRepository todoRep)
        {
            _todoRepository = todoRep;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listTodo = await _todoRepository.GetAll();
            return Ok(listTodo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoById = await _todoRepository.GetById(id);
            return Ok(todoById);
        }

        [HttpGet("descripcion/{desc}")]
        public async Task<IActionResult> GetByDesc(string desc)
        {
            var todosByDesc = await _todoRepository.GetByDesc(desc);
            return Ok(todosByDesc);
        }

        [HttpGet("estado/{state}")]
        public async Task<IActionResult> GetByState(string state)
        {
            var todosByState = await _todoRepository.GetByState(state);
            return Ok(todosByState);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Todo todo)
        {
            var info = await _todoRepository.Create(todo);
            return Ok(new { message = info });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Todo todo)
        {

            var info = await _todoRepository.Update(id, todo);
            return Ok(new { message = info });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var info = await _todoRepository.Delete(id);
            return Ok(new { message = info });
        }
    }
}
