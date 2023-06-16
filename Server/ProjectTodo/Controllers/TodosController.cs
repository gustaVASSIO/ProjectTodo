using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTodo.Models.Entities;
using ProjectTodo.Models.Enums;
using ProjectTodo.Repository.Interfaces;

namespace ProjectTodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TodosController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var todos = await _uow.TodoRepository.Get().ToListAsync();
            
            return Ok(todos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(string id)
        {
            Todo todo = await _uow.TodoRepository.GetById(id);
            if (todo == null)
                return BadRequest("Todo not found");

            return todo;
        }
        
        [HttpGet("Pending")]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodosNotCompleted()
        {
            var todosPending = _uow.TodoRepository.GetTodosNotConcluedOrderByDate();
            return Ok(todosPending);
        }

        [HttpPost]
        public async Task<ActionResult> PostTodo(Todo todo)
        {
            if (DateTime.Compare(todo.DateConclusion.Value.Date, DateTime.Now.Date) < 0)
                return BadRequest("The date to conclusion must be greater than today");

            _uow.TodoRepository.Insert(todo);
            try
            {
               await _uow.Commit();
            }
            catch (DbUpdateException)
            {
                _uow.Dispose();
                return BadRequest("This todo alredy exist in database");
            }
            finally
            {
                _uow.Dispose();
            }
            return CreatedAtAction("GetTodo", new { id = todo.TodoId }, todo);
        }

        [HttpPatch("State/{id}")]
        public async Task<ActionResult> MarkTodoCompleted(string id)
        {
            Todo todo = await _uow.TodoRepository.GetById(id);
            
            if (todo == null)
                return BadRequest("Todo not found");

            todo.State = TodoState.COMPLETED;
            _uow.TodoRepository.Update(todo);
            try
            {
                await _uow.Commit();
            }
            catch (DbUpdateException)
            {
                _uow.Dispose();
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            finally
            {
                _uow.Dispose();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(string id)
        {
            var todo = await _uow.TodoRepository.GetById(id);
            
            if (todo == null)
                return BadRequest("Todo not found");

            _uow.TodoRepository.Delete(todo);
            
            try
            {
                await _uow.Commit();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
            finally
            {
                _uow.Dispose();
            }

            return NoContent();
        }

    }
}
