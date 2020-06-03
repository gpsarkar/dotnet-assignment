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
            catch (ArgumentException)
            {
                Assert.True(true);
            }
            Assert.True(false);
        }
        [Fact]
        public void PassinglimitedArguments()
        {
            string[] args = {"--log-dir",".","--csv","."};
            var parser = new ArgParser();
            try
            {
                parser.ParseArgs(args);
            }
            catch (ArgumentException)
            {
                Assert.True(true);
            }
            Assert.True(false);
        }
        [Fact]
        public void PassingWrongArguments()
        {
            string[] args = {"--log","."};
            var parser = new ArgParser();
            try
            {
                parser.ParseArgs(args);
            }
            catch (ArgumentException)
            {
                Assert.True(true);
            }
            Assert.True(false);
        }

        [Fact]
        public void PassingCorrectArguments()
        {
            string[] args = {"--log-dir","bin","--csv","bin","--log-level","INFO"};
            var parser = new ArgParser();
            try
            {
                parser.ParseArgs(args);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
            Assert.True(true);
        }
    }
}
