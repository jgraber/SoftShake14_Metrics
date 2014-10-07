using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConfiguration
{
    public class LogExamples
    {
        public static void WriteLogMessages()
        {
            Log.Information("A simple info message");

            Log.Debug("Debug is only for internal use");

            Log.Error("Now we have an error!");


            var dividend = 10;
            var divisor = 0;

            try
            {
                var result = dividend / divisor;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The division {dividend}/{divisor} failed", dividend, divisor);
            }

        }
    }
}
