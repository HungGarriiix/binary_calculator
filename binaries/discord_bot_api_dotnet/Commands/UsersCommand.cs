using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace discord_bot_api_dotnet.Commands
{
    public class UsersCommand: BaseCommandModule
    {
        [SlashCommand("user", "Getting registered user information")]
        public async Task GetUser(CommandContext ctx, int user_id)
        {

        }
    }
}
