using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;

namespace PublisherBot.Server.Core
{
    /// <summary>
    /// Class for messages handle
    /// </summary>
    public abstract class Message: IMessage
    {
        /// <summary>
        /// Message type in Telegram
        /// </summary>
        public MessageType Type { get; set; }

        /// <summary>
        /// Message status.
        /// If the message was sent then true is false otherwise
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Method for sending messages of different types
        /// </summary>
        public abstract Task Send();
    }
}
