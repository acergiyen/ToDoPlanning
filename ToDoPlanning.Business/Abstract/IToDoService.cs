using ToDoPlanning.Models.Response.Web;

namespace ToDoPlanning.Business.Abstract;

public interface IToDoService
{
    Task<PlanningViewModel> Plan(int maxWorkingHoursForDeveloper);

}