using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uwu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            Config.LoadConfig();

            DiscordClient discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = Config.token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents,
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("uwu"))
                    await e.Message.RespondAsync("owo");
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);

        }
    }
}
