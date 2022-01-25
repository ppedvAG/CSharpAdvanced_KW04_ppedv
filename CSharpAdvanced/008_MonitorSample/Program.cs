using System;
using System.Threading;

namespace _008_MonitorSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void KritischerCodeAbschnitt()
        {
            int x = 1; //x muss auf 1 gesetzt weden 
            Monitor.Enter(x); //Nur ein Thread darf intern verwendet werden, weitere müssen hier warten 
            
            try
            {
                //Mach Etwas 
            }
            finally
            {
                Monitor.Exit(x); //Sperre wird wieder aufgehoben
            }
        }
    }
}
