using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConvertLogToCsv
{
    public class ArgParser
    {
        private List<String> arg = new List<string>();

        public ArgParser(string[] args)
        {
            Regex cmdRegEx = new Regex(@"/(?<name>.+?):(?<val>.+)");

            Dictionary<string, string> cmdArgs = new Dictionary<string, string>();
            foreach (string s in args)
            {
                Match m = cmdRegEx.Match(s);
                if (m.Success)
                {
                    cmdArgs.Add(m.Groups[1].Value, m.Groups[2].Value);
                }
            }
        }
    }
}