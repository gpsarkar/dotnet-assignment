using System;
using System.IO;
using Xunit;

namespace LogParser.Tests
{
    public class ArgParseTest
    {
        [Fact]
        public void PassingNoArguments()
        {
            string[] args = {""};
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

        }
        [Fact]
        public void PassinglimitedArguments()
        {

        }
        [Fact]
        public void PassingWrongArguments()
        {

        }
        [Fact]
        public void PassingHelpArguments()
        {

        }
        [Fact]
        public void PassingCorrectArguments()
        {

        }
    }
}
