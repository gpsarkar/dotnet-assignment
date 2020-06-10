using System;
using System.IO;

namespace LogParser
{
    public class ConverterFromLogToCSV
    {
        public int count {get; set;} // GS - Make private if use only inside class
        
        public ConverterFromLogToCSV()
        {
            count = 0;
        }

        // GS - Just a convention - Public method should begin with upperccase `Convert()`
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

            // GS - FYI - Using can be used in a new way with C#8
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/using#detailed-design
            // It makes your statements like this:-
            /*------
                using var writer = new StreamWriter($"{args.csv}/log.csv", true);
                using var reader = File.OpenText(filename);
                var line = reader.ReadLine();
                while (line != null)
                {
                    ....
                    ....
                    ...
                }
            -----*/
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
                                count++;
                                writter.WriteLine($"{count},{formatdata.GetString()}");
                            }
                        }
                        line = reader.ReadLine();
                    }
                }
            }
        }

        private bool CheckvalidLine(string line) // GS - Simple method like this can be made static
        {
            return line.Contains(":.");
        }

        private string[] GetLogFiles(string logdir) // GS - Simple method like this can be made static
        {
            string[] logfiles = Directory.GetFiles(logdir, "*.log", SearchOption.AllDirectories);
            return logfiles;
        }
    }
}