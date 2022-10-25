using CrossSync.AspNetCore.Api;
using CrossSync.Entity.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

using CrossSync.Entity.Abstractions.UnitOfWork;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace Sample.TodoList.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : SyncController<TodoList.Entities.Shared.TodoList>
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public TodoListController(IUnitOfWork unitOfWork, ISyncRepository<TodoList.Entities.Shared.TodoList> repository) : base(unitOfWork, repository)
        {
        }
        protected override IQueryable<TodoList.Entities.Shared.TodoList> Includes(IQueryable<TodoList.Entities.Shared.TodoList> query)
        {
            return query.Include(x=>x.Items);
        }

    }
}