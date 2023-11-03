using Quartz;
using Rest.Jobs;

namespace Rest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Quartz hosted service START
            builder.Services.AddQuartz(q =>
            {
                var notificationJobKey = new JobKey(nameof(NotificationJob));
                // job
                q.AddJob<NotificationJob>(notificationJobKey);
                // trigger - every 30 seconds!
                q.AddTrigger(trigger => trigger
                    .ForJob(notificationJobKey)
                    .WithSimpleSchedule(sch =>
                        sch.WithIntervalInSeconds(30).RepeatForever()));

            });
            builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            // Quartz END


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}