using System;
using System.IO;

namespace LogParser
{
    public class Help
    {
        public static void PrintHelp()
        {
            Console.WriteLine("Usage: logParser --log-dir <dir> --log-level <level> --csv <out> \n" ,
                                "--log-dir   Directory to parse recursively for .log files \n ",
                                "--csv       Out file-path (absolute/relative)");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}