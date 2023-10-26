using binaries_cal.Calculations;
using binaries_cal.Logics;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace discord_bot_api_dotnet.Commands
{
    public class CalCommands : BaseCommandModule
    {
        private CalculatorMain _main = new CalculatorMain("Test");  // Lemme think how to get the user's names

        [Command("cal")]
        public async Task Calculate(CommandContext ctx, int cal_mode, string input)
        {
            _main.CollectionCal.AddNewCal(CalculatorProcessor.MakeCalculation(input, cal_mode));
            ICal current_cal = _main.MainCal.CurrentCal;
            if (current_cal != null)
            {
                var result = new DiscordEmbedBuilder()  // main calculation result content
                {
                    Title = current_cal.ModeTitle,
                    Description = current_cal.ResultFull,
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
            _main.CollectionCal.AddNewCal(CalculatorProcessor.MakeCalculation(input, cal_mode_1, cal_mode_2));
            ICal current_cal = _main.MainCal.CurrentCal;
            if (current_cal != null)
            {
                var result = new DiscordEmbedBuilder()  // main calculation result content
                {
                    Title = current_cal.ModeTitle,
                    Description = current_cal.ResultFull,
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
