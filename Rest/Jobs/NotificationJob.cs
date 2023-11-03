using Quartz;

namespace Rest.Jobs
{
    [DisallowConcurrentExecution]
    public class NotificationJob : IJob
    {
        private readonly ILogger<NotificationJob> _logger;


        public NotificationJob(ILogger<NotificationJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            // write your task here!
            return Task.CompletedTask;
        }
    }
}
