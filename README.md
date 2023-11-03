# Quartz job example 
A simple example to run background jobs with asp.net core applicaiton. 


```
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
```

The project has an empty job called ```NotificaitonJob```. Put a breakpoint and check if it is called every 30 seconds!

Enjoy!