using ex2.Models;
using ex2.Repositories;

namespace ex2.Services
{
    public class AdoServices : IAdoServices
    {
        private readonly IAdoRepository _AdoRepository;
        public AdoServices(IAdoRepository AdoRepository)
        {
            _AdoRepository = AdoRepository;
        }
        public bool ProcessTransaction(TaskAndAttechment taskAndAttechment)
        {
           return _AdoRepository.ProcessTransaction(taskAndAttechment);
        }
    }
}
