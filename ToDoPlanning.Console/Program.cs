using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoPlanning.Business.Abstract;
using ToDoPlanning.Business.Concrete;
using ToDoPlanning.Console.Config;
using ToDoPlanning.Console.Helpers;
using ToDoPlanning.Data;
using ToDoPlanning.Data.Repositories.Abstract;
using ToDoPlanning.Data.Repositories.Concrete;
using ToDoPlanning.Models.Response.API;
using Task = ToDoPlanning.Models.Response.API.Task;

var currentDirectory = Directory.GetCurrentDirectory();
var configFilePath = Path.Combine(currentDirectory, "Config", "Config.yaml");
var config = Config.LoadConfig(configFilePath);

var apiHelper = new ApiHelper();

List<Task> tasks = new List<Task>();

foreach (var provider in config.application.providers)
{
    Model  response = await apiHelper.GetDataAsync(provider);
    
    tasks.AddRange(response.Tasks);
}

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(( services) =>
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(config.database.connectionString);
        });
        services.AddTransient<ITaskItemRepository, TaskItemRepository>();
        services.AddTransient<ITaskItemService, TaskItemService>();
    })
    .Build();

var serviceProvider = host.Services;
var taskService = serviceProvider.GetRequiredService<ITaskItemService>();

var mappingHelper = new MappingHelper();
var taskItems = mappingHelper.MapTaskToTaskItem(tasks);

 await taskService.AddTaskItems(taskItems);
