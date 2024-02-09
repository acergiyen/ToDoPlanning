using ToDoPlanning.Business.Abstract;
using ToDoPlanning.Data.Entities;
using ToDoPlanning.Data.Repositories.Abstract;

namespace ToDoPlanning.Business.Concrete
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _taskItemRepository = taskItemRepository ?? throw new ArgumentNullException(nameof(taskItemRepository));
        }

        public async Task AddTaskItems(List<TaskItem> tasks)
        {
            foreach (var task in tasks)
            {
                var taskEntity = new TaskItem
                {
                    Name = task.Name,
                    Duration = task.Duration,
                    Difficulty = task.Difficulty,
                };

                if (task.DeveloperId.HasValue)
                {
                    taskEntity.DeveloperId = task.DeveloperId;
                }

                await _taskItemRepository.Add(taskEntity);
            }
        }

        public async Task<List<TaskItem>> GetAllTaskItem()
        {
            var tasks = await _taskItemRepository.GetAll();

            return tasks.Select(x => new TaskItem
            {
                Name = x.Name,
                Difficulty = x.Difficulty,
                Duration = x.Duration
            }).ToList();
        }
    }
}