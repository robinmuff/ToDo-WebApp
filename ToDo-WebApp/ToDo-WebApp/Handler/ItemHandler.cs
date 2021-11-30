namespace ToDo_WebApp.Handler
{
    public class ItemHandler
    {
        public static string accessPath = "/test";
        public static async Task handle(HttpContext httpClient)
        {
            if (httpClient.Request.Method == "GET" && httpClient.Request.Path.Value == accessPath)
            {
                await httpClient.Response.WriteAsJsonAsync(Service.TaskService.getAllTasks(httpClient).Result);
            }
            if (httpClient.Request.Method == "GET" && httpClient.Request.Path.Value == accessPath + "/{id}")
            {
                await httpClient.Response.WriteAsJsonAsync(Service.TaskService.getSpecificTask(httpClient).Result);
            }
            if (httpClient.Request.Method == "POST" && httpClient.Request.Path.Value == accessPath)
            {
                await httpClient.Response.WriteAsJsonAsync(Service.TaskService.postTask(httpClient).Result);
            }
            if (httpClient.Request.Method == "PUT" && httpClient.Request.Path.Value == accessPath + "/{id}")
            {
                await httpClient.Response.WriteAsJsonAsync(Service.TaskService.putTask(httpClient).Result);
            }
            if (httpClient.Request.Method == "DELETE" && httpClient.Request.Path.Value == accessPath + "/{id}")
            {
                await Service.TaskService.deleteTask(httpClient);
                httpClient.Response.StatusCode = 200;
            }
        }
    }
}
