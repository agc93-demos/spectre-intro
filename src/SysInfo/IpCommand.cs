using System;
using System.Net.Http;
using System.Threading.Tasks;
using Spectre.Cli;

namespace SysInfo
{
    public class IpCommand : AsyncCommand<IpCommand.IpCommandSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, IpCommandSettings settings)
        {
            // var client = new HttpClient();
            // var ip = await client.GetStringAsync(settings.RequestUrl);
            // Console.Write(ip);
            // return 0;
            var client = new HttpClient();
            try
            {
                var ip = await client.GetStringAsync(settings.RequestUrl);
                Console.Write(ip);
                return 0;
            }
            catch (System.Exception)
            {
                Console.WriteLine("There was an error retrieving your IP address!");
                return -1;
            }
        }

        public class IpCommandSettings : CommandSettings {
            [CommandOption("--url")]
            public string RequestUrl {get;set;} = "https://ifconfig.co/ip";
        }
    }
}