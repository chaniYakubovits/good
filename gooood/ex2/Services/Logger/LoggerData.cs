using ex2.Models;
using ex2.Repositories;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using ex2.Services.Logger;

namespace ex2.Services.Logger
{
    public class LoggerData : ILoggerService
    {
        private readonly ILoggerService _LoggerData;
        private readonly TasksContext _context;
        string Cnn;
        public LoggerData(TasksContext context)
        {
            _context = context;
        }

        public void Log(string message)
        {
            Logger1 logger = new Logger1();
            logger.Messege = message;
            logger.Date = DateTime.Now;
            _context.Logger1.Add(logger);
            _context.SaveChanges();
        }
    }
}


//public IConfiguration _configuration;
//IConfiguration configuration
//_configuration = configuration;
//Cnn = configuration.GetConnectionString("DefaultConnection");