using Microsoft.EntityFrameworkCore;
using ToDo_WebApp.Handler;
using ToDo_WebApp.DB;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskDBContext>(options => options.UseInMemoryDatabase("Tasks"));
await using var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

ItemHandler.accessPath = "/test";

app.MapGet("/", () => Results.Ok());
app.Map(ItemHandler.accessPath, ItemHandler.handle);
app.MapGet("/tasks", TaskHandler.getAllTasks);
app.MapGet("/tasks/{id}", TaskHandler.getSpecificTask);
app.MapPost("/tasks", TaskHandler.postTask);
app.MapPut("/tasks/{id}", TaskHandler.putTask);
app.MapDelete("/tasks/{id}", TaskHandler.deleteTask);

await app.RunAsync();