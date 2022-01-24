using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandlerSample
{
    public class ProcessBusinessLogic2Component
    {
        //Beispiel 1
        public event EventHandler ProcessCompleted;




        //Beispiel 2: Events mit Argumente
        public event EventHandler ProcessCompletedWithArgument;

        public void StartProcess()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i);

            OnProcessCompleted(EventArgs.Empty);

        }

        public void StartProcess2()
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i);

            MyEventArg myEventArg = new MyEventArg();
            myEventArg.Uhrzeit = DateTime.Now;

            //Wir verwenden ein abgeletietes Event Argument
            OnProcessCompletedNew(myEventArg);
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }

      

        protected virtual void OnProcessCompletedNew(EventArgs e)
        {
            ProcessCompletedWithArgument?.Invoke(this, e);
        }

    }




    public class MyEventArg : EventArgs
    {
        public DateTime Uhrzeit { get; set; }
    }
}
