using System;
using System.Threading;

namespace _010_Mutex_ProgramInstance
{
    internal class Program
    {
        static Mutex mutex;
        
        static void Main(string[] args)
        {
            if(Program.IsSingleInstance())
            {
                Console.WriteLine("One instance");
            }
            else
                Console.WriteLine("More than one instance");

            Console.ReadLine();

        }

        static bool IsSingleInstance()
        {
            if (Mutex.TryOpenExisting("ABC", out mutex))
            {
                return false;
            }
            else
            {
                mutex = new Mutex(false, "ABC"); //hier hinterlegen wir unter ABC, dass diese Instanz zum ersten mal aufgerufen wird. 
                return true; 
            }
        }
    }
}
