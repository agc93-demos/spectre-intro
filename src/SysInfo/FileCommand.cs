using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Spectre.Cli;

namespace SysInfo
{
    public class FileCommand : Command<FileCommand.FileCommandSettings>
    {
        public override int Execute(CommandContext context, FileCommandSettings settings)
        {
            var file = new System.IO.FileInfo(settings.FilePath);
            Console.WriteLine($"{file.Name} (in {file.DirectoryName})");
            Console.WriteLine($"{file.Length} bytes");
            if (settings.IncludeTimes) {
                Console.WriteLine($"Last accessed {file.LastAccessTime.ToString()}");
                Console.WriteLine($"Last modified {file.LastWriteTime.ToString()}");
                Console.WriteLine($"File is {(((file.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly) ? "read-only" : "writeable")}");
            }
            return 0;
        }

        public class FileCommandSettings : CommandSettings {
            [CommandArgument(0, "<FILE>")]
            [Required]
            public string FilePath {get;set;}

            [CommandOption("-t|--times")]
            [Description("Includes file access times and attributes in output.")]
            public bool IncludeTimes {get;set;}
            
        }
    }
}