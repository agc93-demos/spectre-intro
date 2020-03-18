using System;
using System.Linq;
using Spectre.Cli;

namespace SysInfo
{
    public class InterfacesCommand : Command
    {
        public override int Execute(CommandContext context)
        {
            var ifaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (var iface in ifaces)
            {
                Console.WriteLine(iface.Name);
            }
            return 0;
        }
    }
}