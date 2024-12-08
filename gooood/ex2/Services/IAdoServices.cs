using ex2.Models;

namespace ex2.Services
{
    public interface IAdoServices
    {
        public bool ProcessTransaction(TaskAndAttechment taskAndAttechment);
    }
}
