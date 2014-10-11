using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingBetterMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Logger
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.Seq("http://localhost:5341")
                    .CreateLogger();
        }
    }
}
