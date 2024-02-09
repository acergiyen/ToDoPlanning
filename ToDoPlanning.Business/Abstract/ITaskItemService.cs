using ToDoPlanning.Data.Entities;

namespace ToDoPlanning.Business.Abstract
{
    public interface ITaskItemService
    {
        Task AddTaskItems(List<TaskItem> tasks);
        Task<List<TaskItem>> GetAllTaskItem();
    }
}