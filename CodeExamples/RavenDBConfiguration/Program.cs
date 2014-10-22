using Raven.Client.Document;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenDBConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let Serilog write it's own log messages to the console
            Serilog.Debugging.SelfLog.Out = Console.Out;

            // Create document store
            var documentStore = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "Logs"
            };
            documentStore.Initialize();


            // Create Logger
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.RavenDB(documentStore)
                    .CreateLogger();

            LogExamples.WriteLogMessages();
        }
    }
}
