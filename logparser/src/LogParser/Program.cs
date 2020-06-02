using System;
using System.IO;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new ArgParser();
            try
            {
                parser.ParseArgs(args);
            }
            catch (ArgumentException es)
            {
                Console.WriteLine(es);
                Help.PrintHelp();
            }
            catch(DirectoryNotFoundException es)
            {
                Console.WriteLine(es);
                Help.PrintHelp();
            }
            finally
            {
                Console.WriteLine("");
            }
            var conv = new ConverterFromLogToCSV();
            try
            {
                conv.convert(parser.GetArgs());
                Console.WriteLine("Data conveted Successfully");
            }
            catch(Exception es)
            {
                Console.WriteLine(es);
            }
        }
    }
}
