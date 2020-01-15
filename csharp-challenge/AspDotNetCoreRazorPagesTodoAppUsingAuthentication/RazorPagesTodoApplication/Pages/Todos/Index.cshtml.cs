using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTodoApplication.Data;
using RazorPagesTodoApplication.Models;

namespace RazorPagesTodoApplication
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; }

        public async Task OnGetAsync()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Todo = await _context.Todo.Where(o => o.OwnerId == userId).ToListAsync();
        }
    }
}
