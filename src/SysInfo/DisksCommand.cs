using System;
using System.Linq;
using Spectre.Cli;

namespace SysInfo
{
    public class DisksCommand : Command<DisksCommandSettings>
    {
        public override int Execute(CommandContext context, DisksCommandSettings settings)
        {
            var disks = System.IO.DriveInfo.GetDrives().Where(d => d.IsReady);
            if (settings.LocalOnly) {
                disks = disks.Where(d => d.DriveType == System.IO.DriveType.Fixed);
            }
            foreach (var disk in disks)
            {
                Console.WriteLine($"{disk.Name} ({disk.DriveFormat}): {Math.Abs(disk.TotalSize / 1000 / 1000 / 1000)}GB");
            }
            return 0;
        }
    }

    public class DisksCommandSettings : CommandSettings {
        [CommandOption("-l|--local")]
        public bool LocalOnly {get;set;}
    }
}