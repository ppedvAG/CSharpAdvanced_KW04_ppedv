using System;
using System.Threading;

namespace _009_MutexSample
{
    internal class Program
    {
        private static Mutex mutex = null;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void DoSomething()
        {
            mutex = new Mutex(false, "MyMutex");

            bool lockToken = false;

            try
            {
                //lockToken wird auf true gesetzt
                lockToken = mutex.WaitOne();

                //Berechne etwas wichtiges
            }
            finally
            {
                if (lockToken)
                {
                    mutex.ReleaseMutex(); //Codebereich wird für den nächsten Thread freigegeben
                }

            }
        }
    }
}
