using ASP.NET_Core_TODO_List.Data;
using ASP.NET_Core_TODO_List.Models;
using ASP.NET_Core_TODO_List.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_TODO_List.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TodoController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TodoItemViewModel item)
        {
            var data = new TodoItem
            {
              Title = item.Title,
              Description = item.Description,
              DueDate = item.DueDate,
              IsCompleted = item.IsCompleted,
              Priority = item.Priority,

            };

            await dbContext.Todos.AddAsync(data);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Todo");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var Todo = await dbContext.Todos.ToListAsync();

            return View(Todo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var todoItem = await dbContext.Todos.FindAsync(id);

            return View(todoItem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TodoItem viewModel)
        {
            var todoItem = await dbContext.Todos.FindAsync(viewModel.Id);

            if (todoItem != null)
            {
                todoItem.Title = viewModel.Title;
                todoItem.Description = viewModel.Description;
                todoItem.DueDate = viewModel.DueDate;
                todoItem.Priority = viewModel.Priority;
                todoItem.IsCompleted = viewModel.IsCompleted;


                await dbContext.SaveChangesAsync();
            }


            return RedirectToAction("List", "Todo");
        }

        [HttpPost] 
        public async Task<IActionResult> Delete(TodoItem viewModel)
        {
            var todo = dbContext.Todos.Find(viewModel.Id);

            if (todo is not null)
            {
                dbContext.Todos.Remove(todo);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Todo");

        }
    }
}
