using System;
using System.Collections.Generic;
using System.Text;
using PublisherBot.TelegramAPI;
using System.Threading.Tasks;

namespace PublisherBot.Server.Core
{
    public class TextMessage: Message
    {
        public string Text { get; set; }

        public override Task Send()
        {
            return new Task(()=>{ new PostSender(); });
        }
    }
}
