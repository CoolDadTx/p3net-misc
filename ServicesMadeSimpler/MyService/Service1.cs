using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyService
{
    public partial class Service1 : ServiceBase
    {
        public Service1 ()
        {
            InitializeComponent();
            ServiceName = Name;
        }

        public void Start ( string[] args )
        {
            OnStart(args);
        }

        protected override void OnStart ( string[] args )
        {
            m_thread = new Thread(DoWork);
            m_thread.Start();
        }

        protected override void OnStop ()
        {
            if (m_evtTerminate != null)
            {
                m_evtTerminate.Set();

                //Wait for the thread to terminate
                m_thread.Join(StopTimeout);
            };
        }

        public const string Name = "MyService";

        private void DoWork ()
        {
            m_evtTerminate = new ManualResetEvent(false);

            //TODO: Create an initialize worker, alternatively this can be done in OnStart if the service
            //should not start if the worker creation fails
            var worker = new WorkerService();

            do
            {
                worker.DoWork();
            } while (!m_evtTerminate.WaitOne(PollInterval));
        }

        private Thread m_thread;
        private ManualResetEvent m_evtTerminate;

        private const int PollInterval = 5000;
        private readonly TimeSpan StopTimeout = new TimeSpan(0, 0, 10);
    }
}
