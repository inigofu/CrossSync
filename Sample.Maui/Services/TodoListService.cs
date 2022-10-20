using CrossSync.Entity.Abstractions.EF.UnitOfWork;
using CrossSync.Xamarin.DependencyInjection;
using CrossSync.Xamarin.Services;
using Sample.TodoList.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Maui.Services
{
    public class TodoListService : SyncService<TodoList.Entities.Shared.TodoList>, IConflictHandler<TodoList.Entities.Shared.TodoList>
    {
        private readonly IUnitOfWork<TodoListContext> unitOfWork;

        public TodoListService(IUnitOfWork<TodoListContext> unitOfWork, IConnectivityService connectivityService, Lazy<IErrorService> errorService, SyncConfiguration config) : base(unitOfWork, connectivityService, errorService, config)
        {
            this.unitOfWork = unitOfWork;
        }

        public override string ApiUri => "api/todolist";

        public override int Order => 100;

        public async Task<TodoList.Entities.Shared.TodoList> HandleConflict(TodoList.Entities.Shared.TodoList clientValue, TodoList.Entities.Shared.TodoList serverValue)
        {
            var selectedResult = "Keep local version";// await IoC.Resolve<IUserDialogs>().ActionSheetAsync("Conflict resolution", "Keep local version", null, buttons: new[] { "Take Server version" });
            return selectedResult == "Keep local version" ? clientValue : serverValue;
        }
    }
}
