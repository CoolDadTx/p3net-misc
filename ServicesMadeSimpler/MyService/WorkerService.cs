using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyService
{
    //TODO: In a real service this would contain the business logic that can be run in any host (service, console app, task, etc).
    public class WorkerService
    {
        public void DoWork ()
        {
            //TODO: Put real work here
            System.Diagnostics.Debug.WriteLine("Sleeping");
            Thread.Sleep(5000);
            System.Diagnostics.Debug.WriteLine("Slept");
        }
    }
}
