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
                AppendToCsv(filename, args.csv);
            }
        }

        private void AppendToCsv(string filename, string csvdir)
        {
            var csv = new CsvFormatter();
            using (var writter = new StreamWriter($"{csvdir}/log.csv",true))
            {
                using (var reader = File.OpenText(filename))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if(!CheckvalidLine(line))
                        {
                            line = reader.ReadLine();
                            continue;
                        }
                        var formatdata = csv.ParseLine(line);
                        writter.WriteLine($"{count},{formatdata.GetString()}");
                        count ++;
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