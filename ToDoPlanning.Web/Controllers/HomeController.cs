using Microsoft.AspNetCore.Mvc;
using ToDoPlanning.Business.Abstract;

namespace ToDoPlanning.Web.Controllers;

public class HomeController : Controller
{
    private readonly IToDoService _toDoService;
    private readonly IConfiguration _configuration;
    
    public HomeController(IToDoService toDoService,IConfiguration configuration)
    {
        _toDoService = toDoService;
        _configuration = configuration;
    }
    public async Task<IActionResult> Index()
    {
        var maxWorkingHours = _configuration.GetValue<int>("maxWorkingHoursPerWeek");
        var response = await _toDoService.Plan(maxWorkingHours);
        return View(response);
    }

}