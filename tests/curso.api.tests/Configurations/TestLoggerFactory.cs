using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace curso.api.tests.Configurations
{
    public class TestLoggerFactory : ITestLoggerFactory
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly  ILogger _logger;

        public TestLoggerFactory(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;

            var factory = LoggerFactory.Create(c =>
            {
                c.AddFilter("Microsoft", LogLevel.Debug)
                    .AddFilter("Default", LogLevel.Debug)
                    .AddFilter("System", LogLevel.Debug)
                    .AddConsole()
                    .AddEventSourceLogger()
                    .AddDebug();
            });

            _logger = factory.CreateLogger("Integration Tests");
        }


        public void WriteLine(string message)
        {
            _logger.LogWarning(message);
            _testOutputHelper.WriteLine(message);
        }
    }
}
