using static System.Reflection.Metadata.BlobBuilder;
using ex2.Models;
using System.Data;
namespace ex2.Services
{
    public interface ITasksServices
    {
        public IEnumerable<Tasks> Get();
        public IEnumerable<Tasks> GetTaskByUser(int Id);
        public bool Add(Tasks task);
        public void Update(Tasks task);
        public void Delete(int id);

        //public DataTable addAttachment(Attachment attachment);
        //public DataTable getByProject(int ProjactId);
    }
}

