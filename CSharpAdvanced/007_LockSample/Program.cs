using System;
using System.Threading;

namespace _007_LockSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 500; i++)
            //{
            //    //schortcut: STRG + "Punkt" -> bietet das Namespace des jeweiligen Objectes als using an 
            //    ThreadPool.QueueUserWorkItem(MachEinKontoUpdate);
            //}

            ParameterizedThreadStart param = null;
            Thread thread = null;


            for (int i = 0; i < 500; i++)
            {
                param = new ParameterizedThreadStart(MachEinKontoUpdate);
                thread = new Thread(param);
                thread.Start();
            }
            Console.WriteLine("fertig");
            Console.ReadLine();
        }

        private static void MachEinKontoUpdate(object state)
        {
            Random random = new Random();

            for (int i = 0; i < 5000; i++)
            {
                int auswahl = random.Next();
                int betrag = random.Next(0, 1000);

                if (auswahl % 2 == 0)
                {
                    Konto.Einzahlen(betrag);
                }
                else
                    Konto.Einzahlen(betrag);
            }
        }
    }
}
