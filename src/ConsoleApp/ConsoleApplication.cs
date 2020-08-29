using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    public class ConsoleApplication : IConsoleApplication
    {
        private readonly ILogger<ConsoleApplication> _logger;
        private readonly IConfiguration _configuration;

        public ConsoleApplication(ILogger<ConsoleApplication> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void Run()
        {
            var loopTimes = _configuration.GetValue<int>("LoopTimes");

            for (int i = 0; i < loopTimes; i++)
            {
                _logger.LogInformation("Run number {runNumber}", i);
            }
        }
    }
}
