﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace WebMVC.Models.TelegBot
{
    /// <summary>
    /// Устройство бота
    /// </summary>
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>();
            //commandsList.Add(new StartCommand());
            //TODO: Add more commands

            botClient = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url,@"api/bot");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}