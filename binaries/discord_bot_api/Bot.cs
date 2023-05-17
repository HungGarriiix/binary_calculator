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
using binaries;

namespace discord_bot_api
{
    public class Bot
    {
        // main client connection
        public DiscordClient Client { get; private set; }
        
        // interactivity centre: emoji reactions, replies, etc.
        public InteractivityExtension Interactivity { get; private set; }

        // commands centre, where to assign BaseCommandModule classes
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            // JSON reader
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            var configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);

            // Discord client main configuration (for 2 hand shake protocol)
            var config = new DiscordConfiguration()
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug
            };

            Client = new DiscordClient(config);
            
            // Discord events assignments
            Client.Ready += OnClientReady;
            CalculatorProcessor.NotificationTriggered += SendError;

            // Discord command registratiion
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

            // Starts connecting (2 hand shake protocol)
            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private async Task OnClientReady(DiscordClient a, ReadyEventArgs e)
        {
            var channel = await a.GetChannelAsync(1096325997076435075);
            var message = new DiscordEmbedBuilder()
            {
                Title = "Yuuka-chan status:",
                Description = "Calculator: :green_circle: **On!**",
                Color = new DiscordColor("#00fd0a")
            };
            await channel.SendMessageAsync(message).ConfigureAwait(false);

            await Task.CompletedTask;
        }

        private async void SendError(object sender, NotificationTriggeredEventArgs n)
        {
            var channel = await Client.GetChannelAsync(1096325997076435075);
            var error = new DiscordEmbedBuilder()
            {
                Title = "***ERROR!!!!!***",
                Description = n.PrintMessage(),
                Color = DiscordColor.Red
            };
            await channel.SendMessageAsync(error).ConfigureAwait(false);
        }
    }
}
