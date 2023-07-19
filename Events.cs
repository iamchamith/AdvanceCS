using System;
using System.Collections.Generic;
using System.Threading;

namespace CShard
{
    public class Events
    {
        public void Process()
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += SubcriberOne; // subscribe
            bl.ProcessCompleted += SubcriberTwo; // subscribe
            bl.StartProcess();
        }

        // event handler
        void SubcriberOne(object sender, EventArgs e)
        {
            Console.WriteLine("SubcriberOne : Process Completed!");
            Console.WriteLine($"Status \t {(e as ProcessEventArgs).Status}");
        }

        void SubcriberTwo(object sender, EventArgs e)
        {
            Console.WriteLine("SubcriberTwo : Process Completed!");
            Console.WriteLine($"Users are \t {string.Join(",", (e as ProcessEventArgs).Users)}");
        }
    }

    public class ProcessBusinessLogic
    {
        public event EventHandler ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            // load users
            Thread.Sleep(5000);
            var users = new List<string>() { "Chamith", "Maheesh", "Melissa", "Sajeeka" };
            
            // emit event
            ProcessCompleted?.Invoke(this, new ProcessEventArgs()
            {
                Status = true,
                Users = users
            });
        }
    }

    public class ProcessEventArgs : EventArgs
    {
        public bool Status { get; set; }
        public List<string> Users { get; set; } = new List<string>();
    }
}
