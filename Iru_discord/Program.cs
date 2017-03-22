using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iru_discord
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Discord.DiscordClient();
            Console.Out.WriteLine("Enter token");
            string token = Console.ReadLine();

            bot.JoinedServer += Bot_JoinedServer;
            bot.MessageReceived += Bot_MessageReceived;
            bot.ExecuteAndWait(async () =>
            {
                await bot.Connect(token, Discord.TokenType.Bot);
            });

        }

        private static void Bot_MessageReceived(object sender, Discord.MessageEventArgs e)
        {
            CommandSelector.Execute(e);
        }

        private static void Bot_JoinedServer(object sender, Discord.ServerEventArgs e)
        {
            e.Server.DefaultChannel.SendMessage("Hello!");
        }
    }
}
