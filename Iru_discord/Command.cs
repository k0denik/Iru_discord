using System;
using System.Diagnostics.Eventing.Reader;
using Discord;

namespace Iru_discord
{
    public abstract class Command
    {
        protected string ComName;
        protected string[] Args;
        protected CommandHandler Handler;

        protected Command(CommandHandler handler)
        {
            Handler = handler;
            
        }

        public void Start()
        {
            if (this.IsValid())
                this.Run();
            else
                Handler.Send("That command is wrong in some way.");
        }

        protected abstract bool IsValid();

        protected abstract void Run();
    }

    public abstract class CommandHandler
    {
        public abstract String GetName();
        public abstract void Send(string m);
        public abstract String getMessage();
    }

    class DiscordCommandHandler : CommandHandler
    {
        protected Discord.MessageEventArgs EventArgs;

        public DiscordCommandHandler(MessageEventArgs eventArgs)
        {
            EventArgs = eventArgs;
        }

        public override string GetName()
        {
            return EventArgs.User.NicknameMention;
        }

        public override void Send(string m)
        {
            EventArgs.Channel.SendMessage(m);
        }

        public override string getMessage()
        {
            return EventArgs.Message.Text;
        }
    }
}