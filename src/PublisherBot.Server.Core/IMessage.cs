using System.Threading.Tasks;

namespace PublisherBot.Server.Core
{
    /// <summary>
    /// Use this interface for control messages
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Method for send message
        /// </summary>
        Task Send();
    }
}
