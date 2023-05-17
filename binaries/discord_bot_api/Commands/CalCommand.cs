using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using binaries;
using DSharpPlus.Entities;
using DSharpPlus.Net;

namespace discord_bot_api.Commands
{
    public class CalCommands : BaseCommandModule
    {
        private CalculatorMain _main = new CalculatorMain();
        

        [Command("cal")]
        public async Task Calculate(CommandContext ctx, int cal_mode, string input)
        {
            ICal cal = CalculatorProcessor.MakeCalculation(input, cal_mode); // this will be changed later in terms of ICal structure
            if (cal != null)
            {
                var result = new DiscordEmbedBuilder()
                {
                    Title = cal.ModeTitle,
                    Description = cal.ResultFull, // main calculation result content
                    Color = DiscordColor.CornflowerBlue,
                    Author = new DiscordEmbedBuilder.EmbedAuthor()
                    {
                        Name = $"{ctx.Member.DisplayName} #{ctx.Member.Discriminator}",
                        IconUrl = ctx.Member.AvatarUrl
                    }
                };

                await ctx.RespondAsync(result).ConfigureAwait(false);
            }
        }

        [Command("cal")]
        public async Task Calculate(CommandContext ctx, string cal_mode_1, string cal_mode_2, string input)
        {
            ICal cal = CalculatorProcessor.MakeCalculation(input, cal_mode_1, cal_mode_2);
            if (cal != null)
            {
                var result = new DiscordEmbedBuilder()
                {
                    Title = cal.ModeTitle,
                    Description = cal.ResultFull,
                    Color = DiscordColor.CornflowerBlue,
                    Author = new DiscordEmbedBuilder.EmbedAuthor()
                    {
                        Name = $"{ctx.Member.DisplayName} #{ctx.Member.Discriminator}",
                        IconUrl = ctx.Member.AvatarUrl
                    }
                };

                await ctx.RespondAsync(result).ConfigureAwait(false);
            }
        }
    }
}
