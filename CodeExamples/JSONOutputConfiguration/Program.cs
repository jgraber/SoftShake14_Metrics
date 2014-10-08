using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.IOFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONOutputConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Logger
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.Sink(
                        new FileSink("json_logs.txt", new JsonFormatter(), null))
                    .CreateLogger();

            LogExamples.WriteLogMessages();
        }
    }
}
