using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Spectre.Cli;

namespace SysInfo
{
    //[Description("Lists basic user details for the current user.")]
    public class UserCommand : Command
    {
        public override int Execute(CommandContext context)
        {
            Console.WriteLine($"Current user is {System.Environment.UserName} ({(System.Environment.UserInteractive ? "interactive session" : "non-interactive")}");
            Console.WriteLine($"User home: {System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile)}");
            return 0;
        }
    }
}