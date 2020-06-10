// Assuming the data in log file are in format 
//  <date>(month/day) <Time>(hour:minute:second) <loglevel> :. <text>
//
using System;

namespace LogParser
{
    public class CsvData
    {
        public string Level { set; get; }
        public string Date { set; get; }
        public string Time { set; get; }
        public string Text { set; get; }

        public string GetString()
        {
            // GS - Instead of creating a new method here we can override ToString() and use that. Check below
            return $"{Level},{Date},{Time},{Text}";
        }

        // GS -ToString Overriden
        public override string ToString()
        {
            return $"{Level},{Date},{Time},{Text}";
        }
    }
}
