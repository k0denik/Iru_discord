using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Iru_discord
{
    internal class DiceCommand : Command
    {
        public DiceCommand(CommandHandler handler) : base(handler)
        {
        }

        protected override bool IsValid()
        {
            Match match = Regex.Match(Handler.getMessage(), "!roll (\\d*)d(\\d*)");
            if (match.Groups.Count != 2 && match.Groups.Count != 3)
                return false;
            this.Args = new string[2];
            this.Args[0] = match.Groups[1].Value.Trim();
            this.Args[1] = (string)null;
            if (match.Groups.Count == 3)
                this.Args[1] = match.Groups[2].Value.Trim();
            return true;
        }

        protected override void Run()
        {
            try
            {
                if (this.Args[1] == null)
                {
                    Handler.Send("Here you go, I rolled: " + (object)new Random().Next(1, int.Parse(this.Args[0]) + 1));
                }
                else
                {
                    int num = int.Parse(this.Args[0]);
                    StringBuilder stringBuilder = new StringBuilder();
                    Random random = new Random();
                    if (num > 64)
                    {
                        Handler.Send("That's a bit too many numbers ;_:");
                    }
                    else
                    {
                        for (int index = 0; index < num - 1; ++index)
                            stringBuilder.Append(random.Next(1, int.Parse(this.Args[1]) + 1).ToString() + ", ");
                        stringBuilder.Append(random.Next(1, int.Parse(this.Args[1]) + 1));
                        Handler.Send("Here you go, I rolled: " + (object)stringBuilder);
                    }
                }
            }
            catch (Exception ex)
            {
                Handler.Send("I'm sorry, I don't understand.");
            }
        }
    }
}