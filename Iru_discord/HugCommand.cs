namespace Iru_discord
{
    internal class HugCommand : Command
    {
        public HugCommand(CommandHandler handler) : base(handler)
        {
        }

        protected override bool IsValid()
        {
            return Handler.getMessage().StartsWith("!hug");
        }

        protected override void Run()
        {
            Handler.Send($"*Hugs {Handler.GetName()}*");
        }
    }
}