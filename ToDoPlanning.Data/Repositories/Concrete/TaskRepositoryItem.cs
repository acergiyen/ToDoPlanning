using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ToDoPlanning.Data.Entities;
using ToDoPlanning.Data.Repositories.Abstract;

namespace ToDoPlanning.Data.Repositories.Concrete
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task Add(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }
        

        public async Task<bool> Any(Expression<Func<TaskItem, bool>> condition)
        {
            return await _context.Set<TaskItem>().AnyAsync(condition);
        }

        public async Task<IEnumerable<TaskItem>> GetAll()
        {
            return await _context.TaskItems.ToListAsync();
        }

    }
}