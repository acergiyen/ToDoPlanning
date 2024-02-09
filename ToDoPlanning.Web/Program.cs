using Microsoft.EntityFrameworkCore;
using ToDoPlanning.Business.Abstract;
using ToDoPlanning.Business.Concrete;
using ToDoPlanning.Data;
using ToDoPlanning.Data.Repositories.Abstract;
using ToDoPlanning.Data.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("Postgres"));
});


builder.Services.AddTransient<ITaskItemService, TaskItemService>();
builder.Services.AddTransient<IDeveloperRepository, DeveloperRepository>();
builder.Services.AddTransient<IToDoService, ToDoService>();
builder.Services.AddTransient<ITaskItemRepository, TaskItemRepository>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();