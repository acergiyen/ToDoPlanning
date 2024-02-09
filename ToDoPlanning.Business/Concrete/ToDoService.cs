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
        var sortedDevelopers = developers.OrderByDescending(d => d.Capacity).ToList();
        var removableDevelopers = new List<Developer>(sortedDevelopers);
        var tasks = await _taskItemRepository.GetAll();
        var sortedTasks = tasks.OrderByDescending(t => t.Difficulty).ToList();
        var assignedTasks = new List<TaskItem>();

        while (sortedTasks.Any())
        {
            if (removableDevelopers.Count == 0)
            {
                removableDevelopers = new List<Developer>(sortedDevelopers);
            }
            var assignedTasksDuration = GetDeveloperTotalDuration(assignedTasks, removableDevelopers[0].Id);
            if (assignedTasksDuration <= maxWorkingHoursForWeek && assignedTasksDuration+sortedTasks[0].Duration <= maxWorkingHoursForWeek)
            {
                var assignedTask = new TaskItem
                {
                    Id = sortedTasks[0].Id,
                    Name = sortedTasks[0].Name,
                    DeveloperId = removableDevelopers[0].Id
                };
                assignedTasks.Add(assignedTask);
                removableDevelopers.RemoveAt(0);
                sortedTasks.RemoveAt(0);
            }
            else
            {
                for (int i = 0; i < removableDevelopers.Count - 1; i++)
                {
                        Developer temp = removableDevelopers[i];
                        sortedDevelopers.RemoveAt(i);
                        sortedDevelopers.Add(temp);
                        continue;
                }
            }
        }

        var planningViewModel = new PlanningViewModel
        {
            Developers = new List<PlanningViewModel.Developer>(),
            Weeks = FindMaxWeek(sortedDevelopers,assignedTasks,maxWorkingHoursForWeek)
            
        };

        foreach (var dev in sortedDevelopers)
        {
            if (dev.Id != 0)
            {
                List<PlanningViewModel.Task> assigned = GetAssignedTaskForDeveloper(assignedTasks, dev.Id);
                PlanningViewModel.Developer developer = new PlanningViewModel.Developer
                {
                    Name = dev.Name,
                    Tasks = assigned
                };
                planningViewModel.Developers.Add(developer);
            }
        }

        var a = 0;
        

        return planningViewModel;
    }

    private int GetDeveloperTotalDuration(List<TaskItem> assignedTasks, int? developerID)
    {
        int assignedTaskCount = 0;
        var tasks = assignedTasks.Where(task => task.DeveloperId == developerID);

        foreach (var task in tasks)
        {
            assignedTaskCount += task.Duration;
        }

        return assignedTaskCount;
    }

    private List<PlanningViewModel.Task> GetAssignedTaskForDeveloper(List<TaskItem> assignedTasks, int? developerId)
    {
        List<PlanningViewModel.Task> tasks = new List<PlanningViewModel.Task>();

        if (developerId.HasValue)
        {
            foreach (var assignedTask in assignedTasks.Where(d => d.DeveloperId == developerId).ToList())
            {
                PlanningViewModel.Task task = new PlanningViewModel.Task();
                task.Name = assignedTask.Name;
                tasks.Add(task);
            }
        }

        return tasks;
    }

    private int FindMaxWeek(List<Developer> developers, List<TaskItem> assignedTasks,int maxWorkingHoursForWeek)
    {
        int maxWeek = 1;
        int total = 0;
        foreach (var developer in developers)
        {
          var developerTasks=  assignedTasks.Where(d => d.DeveloperId == developer.Id).ToList();

          foreach (var task in developerTasks)
          {

              total += task.Duration;
              if (total / maxWorkingHoursForWeek + 1 > maxWeek)
              {
                  maxWeek = total / maxWorkingHoursForWeek + 1;
              }
          }

        }

        return maxWeek;
    }
    

    

}