using System;
using System.Threading.Tasks;
using Spectre.Cli;

namespace SysInfo
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // return Task.FromResult(0);
            var app = new CommandApp();
            app.Configure(c => {
                c.AddCommand<UserCommand>("user");
                c.AddCommand<DisksCommand>("disks").WithDescription("Lists available disks on the system");
                c.AddCommand<FileCommand>("file").WithExample(new[] {"./file.txt", "-t"});
                // c.AddCommand<InterfacesCommand>("interfaces").WithAlias("links");
                c.AddBranch("network", net => {
                    net.SetDescription("Commands for networking information");
                    net.AddCommand<InterfacesCommand>("interfaces").WithAlias("links");
                    net.AddCommand<IpCommand>("ip");
                });
            });
            return app.RunAsync(args);
        }
    }
}
