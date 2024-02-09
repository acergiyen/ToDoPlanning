


using ToDoPlanning.Data.Entities;

namespace ToDoPlanning.Data.Repositories.Abstract
{
    public interface ITaskItemRepository : IRepository<TaskItem>
    {
        Task Add(TaskItem taskItem);
    }
}