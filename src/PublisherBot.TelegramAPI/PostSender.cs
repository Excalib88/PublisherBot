using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PublisherBot.TelegramAPI
{
    public class PostSender
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly ChatId _chatId; 
        
        public PostSender(TelegramBotClient client, ChatId chatId)
        {
            _telegramBotClient = client;
            _chatId = chatId;
        }

        public PostSender()
        {
        }

        public async void Send(string text)
        {
            await _telegramBotClient.SendTextMessageAsync(_chatId, text);
        }
        
    }
}