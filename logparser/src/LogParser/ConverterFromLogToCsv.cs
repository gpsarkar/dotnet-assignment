using System;
using System.IO;

namespace LogParser
{
    public class ConverterFromLogToCSV
    {
        private string[] logfiles;
        public void convert(Arguments args)
        {
            GetLogFiles(args.logdir);
        }

        private void GetLogFiles(string logdir)
        {
            throw new NotImplementedException();
        }
    }
}