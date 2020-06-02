using System;
using System.IO;

namespace LogParser
{
    public class ConverterFromLogToCSV
    {

        public void convert(Arguments args)
        {
            string[] logfiles = GetLogFiles(args.logdir);
            foreach (var filename in logfiles)
            {
                AppendToCsv(filename, args.csv);
            }
        }

        private void AppendToCsv(string filename, string csvfile)
        {
            var csv = new CsvFormatter();

            using (var writter = new StreamWriter(csvfile))
            {
                using (var reader = File.OpenText(filename))
                {
                        var line = reader.ReadLine();
                        var formatdata = csv.ParseLine(line);
                }
            }
            // var newLine = string.Format("{0},{1}", first, second);
            // writter.WriteLine(line)
            //     csv.AppendLine(newLine);
            // AddRecordToCSV(data);

            // File.WriteAllText(filePath, csv.ToString());
        }

        private string[] GetLogFiles(string logdir)
        {
            string[] logfiles = Directory.GetFiles(logdir, "*.log", SearchOption.AllDirectories);
            return logfiles;
        }
    }
}