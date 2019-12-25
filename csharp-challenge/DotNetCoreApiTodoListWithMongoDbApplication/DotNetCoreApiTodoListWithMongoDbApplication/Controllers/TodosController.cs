using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using DotNetCoreApiTodoListWithMongoDbApplication.DataServices;
using DotNetCoreApiTodoListWithMongoDbApplication.Models;

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
        [HttpGet("List/{id:length(24)}")]
        public async Task<ActionResult<TodoItem>> Get(string id)
        {
            return  await _dataService.GetOneById(id);
        }

        // POST api/<controller>
        [HttpPost("Create")]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("Complete/{id:length(24)}")]
        public void Put(string id, [FromBody]string value)
        {
        }

        // PATCH api/<controller>/5
        [HttpPatch("Update/{id:length(24)}")]
        public void Patch(string id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("Delete/{id:length(24)}")]
        public void Delete(string id)
        {
        }
    }
}
