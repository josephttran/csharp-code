using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RazorPagesWithAdminPages.Data;
using RazorPagesWithAdminPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RazorPagesWithAdminPages.Authorization
{
    public class CreateTodoAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement>, IAuthorizationHandler
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoAuthorizationHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            OperationAuthorizationRequirement requirement)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            string id = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            int maxTodoIncompleted = _context.AdminPage.Find(id).MaxTodoIsIncompleted;
            int currentTodoIncompleted = _context.Todo.Where(x => x.OwnerId == id & x.IsCompleted == false).Count();

            if (currentTodoIncompleted < maxTodoIncompleted)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
