using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using discord_bot_api.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus.Entities;

namespace discord_bot_api
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            var configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);

            var config = new DiscordConfiguration()
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug
            };

            Client = new DiscordClient(config);
            

            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                EnableDefaultHelp = true,
                DmHelp = true,
            };

            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<CalCommands>();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private async Task OnClientReady(DiscordClient a, ReadyEventArgs e)
        {
            var channel = await a.GetChannelAsync(1096325997076435075);
            /*await channel.SendMessageAsync("On!").ConfigureAwait(false);*/
            var message = new DiscordEmbedBuilder()
            {
                Title = "Yuuka-chan status:",
                Description = "Calculator: :green_circle: **On!**",
                Color = new DiscordColor("#00fd0a")
            };
            await channel.SendMessageAsync(message).ConfigureAwait(false);

            await Task.CompletedTask;

            /*return Task.CompletedTask;*/
        }
    }
}
