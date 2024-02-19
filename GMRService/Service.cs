using Quartz;
using Quartz.Impl;
using Topshelf;

namespace GMRService;

public class Service
{
    void Run()
    {
        HostFactory.Run(x => {
            x.Service<TopShelfService>( s => 
                s.Star)
        })
    }
}

public class TopShelfService : ServiceControl
{

    public bool Start(HostControl hostControl)
    {
        ScheduleJob();
    }

    public bool Stop(HostControl hostControl)
    {
        throw new NotImplementedException();
    }
    
    
    private async Task ScheduleJob(string runTime, int iterations)
    {
        // This method contains the scheduling logic as shown previously
        // For brevity, implementation details are assumed to be similar to those described earlier
        var schedulerFactory = new StdSchedulerFactory();
        var scheduler = await schedulerFactory.GetScheduler();
        await scheduler.Start();

        var job = JobBuilder.Create<Job>()
            .WithIdentity("MyJob", "group1")
            .UsingJobData("iterations", iterations)
            .Build();

        // Assuming runTime is something like "22:00" and needs to be parsed to hours and minutes
        var timeParts = runTime.Split(':');
        var hours = int.Parse(timeParts[0]);
        var minutes = int.Parse(timeParts[1]);

        var trigger = TriggerBuilder.Create()
            .WithIdentity("MyTrigger", "group1")
            .StartNow()
            .WithCronSchedule($"0 {minutes} {hours} * * ?") // Schedules the job to run at the specified time
            .Build();

        await scheduler.ScheduleJob(job, trigger);
    }
}