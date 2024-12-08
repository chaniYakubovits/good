using ex2.Services.Logger;

namespace ex2.Services.Logger
{
    public class LoggerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public LoggerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ILoggerService GetLogger(string useFileLogger)
        {
            if (useFileLogger == "console")
            {
                return _serviceProvider.GetRequiredService<FileLoggerService>();
            }
            if (useFileLogger == "file")
            {
                return _serviceProvider.GetRequiredService<ConsoleLoggerService>();
            }
           else 
            {
                return _serviceProvider.GetRequiredService<LoggerData>();
        }


        //return _serviceProvider.GetRequiredService<ILoggerService>();
    }
    }
}
