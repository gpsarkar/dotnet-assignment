using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace LogParser
{
    public class ArgParser
    {

        public readonly string[] level = {"INFO","ERROR","WARN","DEBUG"};

        private Arguments arguments = new Arguments();

        public void ParseArgs(string[] args)
        {
            if (Array.IndexOf(args, "--help") >= 0)
            {
                Help.PrintHelp();
            }
            if (args.Length % 2 == 1)
            {
                throw new ArgumentException("Invalid Number Of Arguments");
            }
            for (int i = 0; i < args.Length; i += 2)
            {
                switch (args[i])
                {
                    case "--log-dir":
                        if (Directory.Exists(args[i + 1]))
                        {
                            arguments.logdir = args[i + 1];
                        }
                        else
                        {
                            throw new DirectoryNotFoundException("log dir not found");
                        }
                        break;
                    case "--log-level":
                        arguments.loglevel.Add(args[i + 1]);
                        break;
                    case "--csv":
                        if (Directory.Exists(args[i + 1]))
                        {
                            arguments.csv = args[i + 1];
                        }
                        else
                        {
                            throw new DirectoryNotFoundException("Csv dir not exist");
                        }
                        break;
                    default:
                        throw new ArgumentException($"Invalid Argument {args[i]}");
                }
            }
            if( arguments.csv == "" || arguments.logdir == "" || arguments.loglevel.Count == 0)
            {
                throw new ArgumentException("Auguments missing");
            }
        }
        public Arguments GetArgs()
        {
            return arguments;
        }
    }
}