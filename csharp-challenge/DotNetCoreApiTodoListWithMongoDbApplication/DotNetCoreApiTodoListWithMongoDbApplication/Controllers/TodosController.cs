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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            var result = await _dataService.GetAll();

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // PATCH api/<controller>/5
        [HttpPatch]
        public void Patch(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
