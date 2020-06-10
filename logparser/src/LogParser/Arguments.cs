using System;
using System.Collections.Generic;

namespace LogParser
{
    public class Arguments
    {
        public string logdir;
        public string csv;
        public List<String> loglevel; // GS - use built in type everywhere `string` instead of `String, `int` instead of `Int32` etc

        public Arguments()
        {
            logdir = "";
            csv = "";
            loglevel = new List<string>();
        }

        public bool CheckArgs()
        {
            // GS - can be simplified as 
            // return csv != "" && logdir != "" && loglevel.Count != 0;

            if ( csv == "" || logdir == "" || loglevel.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}