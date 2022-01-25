using System;
using System.Threading;
using System.Threading.Tasks;

namespace _03_TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //.NET 4.0  -> starten des Tasks erfolgt automatisch 
            Task task = Task.Factory.StartNew(MachEtwasInEinemThread);
            
            task.Wait();

            //.NET 4.5 - Intern wird Task.Factory.StartNew aufgerufen -> Task.Run dient lediglich als verkürzte Schreibweise.
            Task task2 = Task.Run(MachEtwasInEinemThread);

            Task.Run(MachEtwasInEinemThread).


            
            Console.WriteLine("bin fertig");
            Console.ReadLine();
        }

        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("#");
            }
        }
    }
}
