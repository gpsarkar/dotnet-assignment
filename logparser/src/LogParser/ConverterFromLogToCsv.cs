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

        private void AppendToCsv(string filename, string csvfile)
        {
            var csv = new CsvFormatter();

            
            using (var writter = File.AppendText(csvfile))
            {
                using (var reader = File.OpenText(filename))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var formatdata = csv.ParseLine(line);
                        writter.WriteLine($"{count},{formatdata.GetString()}");
                        count ++;
                        line = reader.ReadLine();
                    }
                }
            }
            //using (var writter = new StreamWriter(csvfile))
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