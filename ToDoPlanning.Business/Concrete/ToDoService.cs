using ToDoPlanning.Business.Abstract;
using ToDoPlanning.Data.Entities;
using ToDoPlanning.Data.Repositories.Abstract;
using ToDoPlanning.Models.Response.Web;

namespace ToDoPlanning.Business.Concrete;

public class ToDoService : IToDoService
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IDeveloperRepository _developerRepository;
    public ToDoService(ITaskItemRepository taskItemRepository,IDeveloperRepository developerRepository)
    {
        _taskItemRepository = taskItemRepository;
        _developerRepository = developerRepository;
    }

    public async Task<PlanningViewModel> Plan(int maxWorkingHoursForWeek)
    {
        var developers = await _developerRepository.GetAll();
        var tasks = await _taskItemRepository.GetAll();

        DistributeTasks(developers, tasks,maxWorkingHoursForWeek);

        int totalWeeks = tasks.Max(t => t.Duration) / maxWorkingHoursForWeek + 1;

        var planningViewModel = new PlanningViewModel
        {
            Developers = developers.Select(d => new PlanningViewModel.Developer
            {
                Name = d.Name,
                Tasks = d.Tasks.Select(t => new PlanningViewModel.Task
                {
                    Name = t.Name
                }).ToList()
            }).ToList(),
            Weeks = totalWeeks
        };

        return planningViewModel;
    }
    
    private void DistributeTasks(IEnumerable<Developer> developers, IEnumerable<TaskItem> tasks, int maxWorkingHoursForDeveloper)
    {
        tasks = tasks.OrderBy(t => t.Difficulty).ThenBy(t => t.Duration);

        int maxDurationPerWeekPerDeveloper = maxWorkingHoursForDeveloper * 5; 

        foreach (var task in tasks)
        {
            var availableDevelopers = developers
                .Where(d => d.Capacity >= task.Duration)
                .OrderBy(d => d.Capacity);

            var assignableDevelopers = availableDevelopers
                .Where(d => d.Capacity >= maxDurationPerWeekPerDeveloper);

            var developer = assignableDevelopers.Any() ? assignableDevelopers.First() : availableDevelopers.FirstOrDefault();

            if (developer != null)
            {
                developer.Tasks ??= new List<TaskItem>();
                developer.Tasks.Add(task);
                developer.Capacity -= task.Duration;
            }
        }
    }

}