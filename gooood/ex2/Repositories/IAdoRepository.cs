using ex2.Models;

namespace ex2.Repositories
{
    public interface IAdoRepository
    {
        public bool ProcessTransaction(TaskAndAttechment taskAndAttechment);
        //public DataTable getByProject(int ProjactId);
        //public DataTable addAttachment(Attachment attachment);
    }
}
