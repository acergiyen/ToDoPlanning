using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoPlanning.Data.Entities;
using ToDoPlanning.Data.Repositories.Abstract;

namespace ToDoPlanning.Data.Repositories.Concrete
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ApplicationDbContext _context;

        public DeveloperRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> Any(Expression<Func<Developer, bool>> condition)
        {
            return await _context.Set<Developer>().AnyAsync(condition);
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            return await _context.Developers.ToListAsync();
        }
    }
}