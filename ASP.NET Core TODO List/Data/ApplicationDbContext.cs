using ASP.NET_Core_TODO_List.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ASP.NET_Core_TODO_List.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }
    }
}
