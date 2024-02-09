using System.Linq.Expressions;

namespace ToDoPlanning.Data.Repositories.Abstract
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<bool> Any(Expression<Func<T, bool>> condition);

    }
}