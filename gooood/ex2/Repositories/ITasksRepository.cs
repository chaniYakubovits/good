using ex2.Models;
using System.Data;
namespace ex2.Repositories
{
    public interface ITasksRepository
    {
        public IEnumerable<Tasks> Get();
        public bool add(Tasks task);
        public void update(Tasks task);
        public void delete(Tasks task);
        public IEnumerable<Tasks> GetTaskByUser(int Id);
    }
}
