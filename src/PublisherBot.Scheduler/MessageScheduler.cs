using PublisherBot.Scheduler;
using Quartz;
using Quartz.Impl;

public class MessageScheduler
{
    public static async void Start()
    {
        var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
        await scheduler.Start();

        var job = JobBuilder.Create<PublishMessageJob>().Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity("PublishTrigger", "Telegram")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInHours(1)
                .RepeatForever())
            .Build();

        await scheduler.ScheduleJob(job, trigger);
    }
}