using System;

namespace Iru_discord
{
    public static class CommandSelector
    {
        public static void Execute(Discord.MessageEventArgs e)
        {
            Command comm = null;
            String m = e.Message.RawText;
            CommandHandler hand = new DiscordCommandHandler(e);
            if (m.StartsWith("!hug"))
                comm = new HugCommand(hand);
            if (m.StartsWith("!roll"))
                comm = new DiceCommand(hand);
            if (m.StartsWith("!memo"))
            {
                comm = new MemoCommand(hand);
            }
            
            comm?.Start();
            RollForMeme(e);
        }

        private static void RollForMeme(Discord.MessageEventArgs e)
        {
            String m = e.Message.RawText;
            if (m.Contains("huh"))
            {
                if (new Random().Next(3) == 1)
                {
                    e.Channel.SendMessage("huh?");
                }
            }
            else if(m.StartsWith(">"))
            {
                if (new Random().Next(150)==1)
                {
                    e.Channel.SendMessage(">implying");
                }
            }
        }
    }
}