using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Logger
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .CreateLogger();

            LogExamples.WriteLogMessages();
        }
    }
}
