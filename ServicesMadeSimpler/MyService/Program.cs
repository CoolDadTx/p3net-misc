using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main ( string[] args )
        {
            var settings = ParseCommandLine(args);

            var service = new Service1();

            if (settings.RunAsConsole)
            {
                Console.WriteLine("Starting service...");           
                service.Start(args);
                Console.CancelKeyPress += (o,e) => 
                {
                    e.Cancel = true;
                    m_evtTerminate.Set();                    
                };

                Console.WriteLine("Press Ctrl+C or Ctrl+Break to quit");
                m_evtTerminate.WaitOne();

                Console.WriteLine("Stopping service...");
                service.Stop();
            } else
                ServiceBase.Run(service);
        }
        
        static ManualResetEvent m_evtTerminate = new ManualResetEvent(false);

        static ProgramSettings ParseCommandLine ( IEnumerable<string> args )
        {
            var settings = new ProgramSettings();

            if (args != null)
            {
                foreach (var arg in args)
                {
                    var token = arg.TrimStart('-', '/');

                    if (String.Compare(token, "console", true) == 0)
                        settings.RunAsConsole = true;
                };
            };

            return settings;
        }

        internal sealed class ProgramSettings
        {
            public bool RunAsConsole { get; set; }
        }
    }
}
