namespace ToDo_WebApp.Handler
{
    public class TaskHandler
    {
        public static async Task getAllTasks(HttpContext http)
        {
            await http.Response.WriteAsJsonAsync(Service.TaskService.getAllTasks(http).Result);
        }
        public static async Task getSpecificTask(HttpContext http)
        {
            await http.Response.WriteAsJsonAsync(Service.TaskService.getSpecificTask(http).Result);
        }
        public static async Task postTask(HttpContext http)
        {
            await http.Response.WriteAsJsonAsync(Service.TaskService.postTask(http).Result);
        }
        public static async Task putTask(HttpContext http)
        {
            await http.Response.WriteAsJsonAsync(Service.TaskService.putTask(http).Result);
        }
        public static async Task deleteTask(HttpContext http)
        {
            await Service.TaskService.deleteTask(http);
            http.Response.StatusCode = 200;
        }
    }
}
