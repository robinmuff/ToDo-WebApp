using Microsoft.EntityFrameworkCore;

namespace ToDo_WebApp.Service
{
    public class ItemService
    {
        public static async Task<List<Class.Task>> getAllTasks(HttpContext http)
        {
            var dbContext = http.RequestServices.GetService<DB.TaskDBContext>();
            return await dbContext.TodoItems.ToListAsync();
        }
        public static async Task<Class.Task> getSpecificTask(HttpContext http)
        {
            if (!http.Request.RouteValues.TryGetValue("id", out var id))
            {
                Results.NotFound();
            }

            var dbContext = http.RequestServices.GetService<DB.TaskDBContext>();
            var todoItem = await dbContext.TodoItems.FindAsync(int.Parse(id.ToString()));
            if (todoItem == null)
            {
                Results.NotFound();
            }
            return todoItem;
        }
        public static async Task<Class.Task> postTask(HttpContext http)
        {
            try
            {
                var todoItem = await http.Request.ReadFromJsonAsync<Class.Task>();
                var dbContext = http.RequestServices.GetService<DB.TaskDBContext>();
                if (dbContext.TodoItems.Count() == 0)
                {
                    todoItem.id = 0;
                }
                else
                {
                    todoItem.id = dbContext.TodoItems.Last().id + 1;
                }
                dbContext.TodoItems.Add(todoItem);
                await dbContext.SaveChangesAsync();
                return todoItem;
            }
            catch
            {
                http.Response.StatusCode = 500;
                return null;
            }
        }
        public static async Task<Class.Task> putTask(HttpContext http)
        {
            if (!http.Request.RouteValues.TryGetValue("id", out var id))
            {
                http.Response.StatusCode = 400;
                return null;
            }

            var dbContext = http.RequestServices.GetService<DB.TaskDBContext>();
            var todoItem = await dbContext.TodoItems.FindAsync(int.Parse(id.ToString()));
            if (todoItem == null)
            {
                http.Response.StatusCode = 404;
                return null;
            }

            var inputTodoItem = await http.Request.ReadFromJsonAsync<Class.Task>();
            todoItem.title = inputTodoItem.title;
            todoItem.description = inputTodoItem.description;
            todoItem.status = inputTodoItem.status;
            await dbContext.SaveChangesAsync();

            return inputTodoItem;
        }
        public static async Task deleteTask(HttpContext http)
        {
            if (!http.Request.RouteValues.TryGetValue("id", out var id))
            {
                http.Response.StatusCode = 400;
                return;
            }

            var dbContext = http.RequestServices.GetService<DB.TaskDBContext>();
            var todoItem = await dbContext.TodoItems.FindAsync(int.Parse(id.ToString()));
            if (todoItem == null)
            {
                http.Response.StatusCode = 404;
                return;
            }

            dbContext.TodoItems.Remove(todoItem);
            await dbContext.SaveChangesAsync();
        }
    }
}