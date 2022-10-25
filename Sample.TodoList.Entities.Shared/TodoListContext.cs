using System;
using System.Collections.Generic;
using System.Text;
using CrossSync.Entity.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sample.TodoList.Entities.Shared.Configurations;

namespace Sample.TodoList.Entities.Shared
{
  public class TodoListContext :
#if SERVER
    CrossSync.Infrastructure.Server.ServerContext
#else
    CrossSync.Infrastructure.Client.ClientContext
#endif
  {
#if SERVER
    private readonly IOptions<API.ConnectionStringOptions> options;

    public TodoListContext(IOptions<API.ConnectionStringOptions> options)
    {
      this.options = options;
    }
#else
    private readonly string path;

    public TodoListContext() : this(@"c:\")
    {
    }

    public TodoListContext(string path)
    {
      this.path = path;
            this.Database.EnsureCreated();
    }
#endif

    public DbSet<TodoList> TodoLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new TodoListConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

#if SERVER
      optionsBuilder.UseInMemoryDatabase("TodoList");
#else
      optionsBuilder.UseSqlite($"FileName={path}");
#endif
    }
  }
}
