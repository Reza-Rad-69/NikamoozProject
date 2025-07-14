using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
using taskSession2.InfraStructures.Data.EF.SqlServer.Common;
using taskSession2.InfraStructures.Data.EF.SqlServer.StatusTask;
using taskSession2.InfraStructures.Data.EF.SqlServer.Tasks;
using taskSession2.taskSession2.Core.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TasksContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Tasks")));
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<StatusTaskRepository>();

var app = builder.Build();

app.Run(async (context) =>
{
    var rTask = context.RequestServices.GetRequiredService<TaskRepository>();
    var rStatusTask = context.RequestServices.GetRequiredService<StatusTaskRepository>();
    if (context.Request.Method == "GET")
    {
        if (context.Request.Path.StartsWithSegments("/GetAll"))
        {
            context.Response.ContentType = "text/html";
            var taskInfo = rTask.GetAll();
            foreach (var item in taskInfo)
            {
                if (item.id == 0)
                {
                    continue;
                }
                await context.Response.WriteAsync($"Id:{item.id} Description:{item.Description} <br>");
            }

        }
        if (context.Request.Path.StartsWithSegments("/Get"))
        {
            context.Response.ContentType = "text/html";
            int id = int.Parse(context.Request.Query["id"]);
            var get = rTask.Get(id);

            await context.Response.WriteAsync($"Id:{get.id} Description:{get.Description} <br>");
        }
    }

    if (context.Request.Method == "DELETE")
    {
        if (context.Request.Path.StartsWithSegments("/Del"))
        {
            if (context.Request.Query.Keys.Contains("id"))
            {
                int id = int.Parse(context.Request.Query["id"]);
                rStatusTask.Delete(id);
                rTask.Delete(id);
                context.Response.StatusCode = 204;
            }
            else
            {
                context.Response.StatusCode = 401;
            }
        }
    }

    if (context.Request.Method == "POST")
    {
        if (context.Request.Path.StartsWithSegments("/Add"))
        {
            StreamReader streamReader = new StreamReader(context.Request.Body);
            string body = await streamReader.ReadToEndAsync();
            var task = JsonSerializer.Deserialize<taskSession2.taskSession2.Core.Domain.Tasks.Task>(body);
            var taskStatus = JsonSerializer.Deserialize<StatusTask>(body);
            if (task != null)
            {
                var insertedTask = rTask.Add(task);
                taskStatus.TaskId = insertedTask.id;
                rStatusTask.Add(taskStatus);
                context.Response.StatusCode = 201;
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }
    }

    if (context.Request.Method == "PUT")
    {
        if (context.Request.Path.StartsWithSegments("/Edit"))
        {
            StreamReader streamReader = new StreamReader(context.Request.Body);
            string body = await streamReader.ReadToEndAsync();
            var task = JsonSerializer.Deserialize<taskSession2.taskSession2.Core.Domain.Tasks.Task>(body);
            var taskStatus = JsonSerializer.Deserialize<StatusTask>(body);
            if (task != null)
            {
                rStatusTask.Update(taskStatus);
                rTask.Update(task);
                context.Response.StatusCode = 201;
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }
    }
});
app.Run();
