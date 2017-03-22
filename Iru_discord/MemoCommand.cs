using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace Iru_discord
{
    internal class MemoCommand : Command
    {
        public MemoCommand(CommandHandler handler) : base(handler)
        {
        }

        protected override bool IsValid()
        {
            Match match = Regex.Match(Handler.getMessage(), "!memo (\\S+)(.*)");
            if (match.Groups.Count != 3)
                return false;
            this.Args = new string[2];
            this.Args[0] = match.Groups[1].Value.Trim();
            this.Args[1] = match.Groups[2].Value.Trim();
            return true;
        }

        protected override void Run()
        {
            // return $"Memo {name}: {text}";
            try
            {
                if (this.Args[1].Equals(""))
                {
                    string path = $"memo/m{Args[0].GetHashCode()}.txt";
                    if (!File.Exists(path))
                    {
                        Handler.Send("I don't have a memo like that.");
                    }
                    else
                    {
                        String name;
                        String text;
                        using (StreamReader fileStream = File.OpenText(path))
                        {
                            name = fileStream.ReadLine();
                            text = fileStream.ReadLine();
                        }
                        Handler.Send($"Memo {name}: {text}");
                    }
                }
                else
                {
                    
                    if (!Directory.Exists("memo"))
                        Directory.CreateDirectory("memo");
                    using (FileStream fileStream = File.Create($"memo/m{Args[0].GetHashCode()}.txt"))
                    {
                        StreamWriter outWriter = new StreamWriter(fileStream);
                        outWriter.WriteLine(Args[0]);
                        outWriter.WriteLine(Args[1]);
                        outWriter.Flush();
                        outWriter.Close();
                    }
                    Handler.Send("Ok, I got it!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
    }
}