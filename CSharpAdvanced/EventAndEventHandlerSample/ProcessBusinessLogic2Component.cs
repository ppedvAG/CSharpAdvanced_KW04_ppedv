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
        public event EventHandler ProcessCompleted; //Hier wird die Adresse der Callback-Methode hinterlegt




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

            //Beispiel 1 - Ohne Argumente
            OnProcessCompleted(EventArgs.Empty);

            //Beispiel 2 - Wir verwenden ein abgeletietes Event Argument
            MyEventArg myEventArg = new MyEventArg();
            myEventArg.Uhrzeit = DateTime.Now;
            OnProcessCompletedNew(myEventArg);
        }

        //Hier rufen wir die Callback Methode auf 
        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e); //Invoke -> Rufen Speicheradresse der Callback-Methode
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
