using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Sinks.Elasticsearch;

namespace ElasticsearchConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create URI to the Elasticsearch server
            var elasticServer = new Uri("http://localhost:9200");

            // Create Logger
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(elasticServer))
                    .CreateLogger();
            LogExamples.WriteLogMessages();
        }
    }
}
