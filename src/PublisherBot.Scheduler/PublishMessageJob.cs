using PublisherBot.Server.Core;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherBot.Scheduler
{
    public class PublishMessageJob : IJob
    {
        private readonly IEnumerable<IMessage> _message;
        public PublishMessageJob(IEnumerable<IMessage> message)
        {
            _message = message;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _message.FirstOrDefault().Send();
        }
    }
}
