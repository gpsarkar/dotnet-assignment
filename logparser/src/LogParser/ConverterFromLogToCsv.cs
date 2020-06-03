using System;
using System.IO;

namespace LogParser
{
    public class ConverterFromLogToCSV
    {
        private int count = 1;
        public void convert(Arguments args)
        {
            string[] logfiles = GetLogFiles(args.logdir);
            foreach (var filename in logfiles)
            {
                AppendToCsv(filename, args);
            }
        }

        private void AppendToCsv(string filename, Arguments args)
        {
            var csv = new CsvFormatter();
            using (var writter = new StreamWriter($"{args.csv}/log.csv", true))
            {
                using (var reader = File.OpenText(filename))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (CheckvalidLine(line))
                        {
                            var formatdata = csv.ParseLine(line);
                            if (args.loglevel.Contains(formatdata.GetString().Split(',')[0]))
                            {
                                writter.WriteLine($"{count},{formatdata.GetString()}");
                                count++;
                            }
                        }
                        line = reader.ReadLine();
                    }
                }
            }
        }

        private bool CheckvalidLine(string line)
        {
            return line.Contains(":.");
        }

        private string[] GetLogFiles(string logdir)
        {
            string[] logfiles = Directory.GetFiles(logdir, "*.log", SearchOption.AllDirectories);
            return logfiles;
        }
    }
}