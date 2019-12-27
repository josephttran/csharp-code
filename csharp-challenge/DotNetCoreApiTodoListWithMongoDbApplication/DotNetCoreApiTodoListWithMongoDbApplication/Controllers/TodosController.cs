using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using DotNetCoreApiTodoListWithMongoDbApplication.DataServices;
using DotNetCoreApiTodoListWithMongoDbApplication.Models;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace DotNetCoreApiTodoListWithMongoDbApplication.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly DataService _dataService;

        public TodosController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<controller>
        [HttpGet("List")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            var result = await _dataService.GetAll();

            return Ok(result);
        }

        // GET: api/<controller>/5
        [HttpGet("List/{id:regex(^[[0-9a-z]]{{24}}$)}", Name = "GetTodoItem")]
        public async Task<ActionResult<TodoItem>> Get(string id)
        {
            return await _dataService.GetOneById(id);
        }

        // POST api/<controller>
        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TodoItem>> Create([FromBody]TodoItem todoItem)
        {
            if (todoItem.Id != null)
            {
                if (!Regex.IsMatch(todoItem.Id, "^[0-9a-zA-F]{24}$"))
                {
                    return BadRequest();
                }
            }

            bool result = await _dataService.Create(todoItem);

            if (!result)
            {
                return BadRequest("Id already exist");
            }

            return CreatedAtRoute("GetTodoItem", new { id = todoItem.Id.ToString() }, todoItem);
        }

        // PUT api/<controller>/5
        [HttpPut("Complete/{id:regex(^[[0-9a-z]]{{24}}$)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Complete(string id, [FromBody]TodoItem todoItem)
        {
            if (Regex.IsMatch(id, "^[0-9a-zA-F]{24}$") &&
                todoItem.Id != null &&
                id != todoItem.Id
                )
            {
                return BadRequest("Object id cannot be modified");
            }

            var found = await _dataService.GetOneById(id);

            if (found == null)
            {
                return NotFound();
            }

            await _dataService.Complete(id, todoItem);

            return NoContent();
        }

        // PATCH api/<controller>/5
        [HttpPatch("Update/{id:regex(^[[0-9a-z]]{{24}}$)}")]
        public async Task<IActionResult> Update(string id, [FromBody]string value)
        {
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("Delete/{id:regex(^[[0-9a-z]]{{24}}$)}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var found = await _dataService.GetOneById(id);

            if (found == null)
            {
                return NotFound();
            }

            await _dataService.Delete(id);

            return NoContent();
        }
    }
}
