using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using binaries;

namespace discord_bot_api.Commands
{
    public class CalCommands : BaseCommandModule
    {
        private CalculatorMain _main = new CalculatorMain();

        [Command("pppp")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("cal")]
        public async Task Calculate(CommandContext ctx, int cal_mode, string input)
        {
            await ctx.Channel.SendMessageAsync(CalculatorProcessor.MakeCalculation(input, cal_mode).Result).ConfigureAwait(false);
        }
    }
}
