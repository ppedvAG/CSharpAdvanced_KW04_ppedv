using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandlerSample
{

    public delegate void ChangedPercentValueDelegate(int n);
    public delegate void ResultDelegate(string msg);


    public class ProcessBusinessLogicComponent
    {
        //Die Event-Methoden, die ausserhalb dieser Klasse verwendet werden, sind hier quasi unbekannt.
        //Damit diese bekannt werden, benötigen wir die Möglichkeit deren Funktions-Zeiger als get/set zu speichern 

        public event ChangedPercentValueDelegate ChangedPercentValue; // -> liegt der Funktionszeige von MyApp._processBusinessLogic_ChangedPercentValue
        public event ResultDelegate ResultCompleted;


        public void StartProcess()
        {
            for(int i = 0; i < 100; i++)
            {
                //Wollen wir seperat den Prozentstand nach aussen mitteilen
                OnProcessPercentStatus(i);
            }


            //Hier müssen wir am Ende nach außen mitteilen, was hier drinne geschehen ist 
            OnProcessCompleted();
        }



        //Diese Methoden rufen, die Program.cs -> Event Methode auf
        protected virtual void OnProcessPercentStatus(int percent)
        {
            ChangedPercentValue?.Invoke(percent); // -> 
        }

        protected virtual void OnProcessCompleted()
        {
            ResultCompleted?.Invoke("bin fertig");
        }
    }
}
