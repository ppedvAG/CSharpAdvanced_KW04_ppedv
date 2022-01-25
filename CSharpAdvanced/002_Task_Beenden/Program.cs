using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_Task_Beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ab .NET 4.0
            CancellationTokenSource cts = new CancellationTokenSource();


            try
            {
                Task task = new Task(MeineMethodeMitAbbrechen, cts.Token);
                task.Start();

                Thread.Sleep(5000);
                //Task.Delay(5000);
                cts.Cancel();
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }

            Console.ReadLine();
        }


        private static void MeineMethodeMitAbbrechen(object param)
        {
            CancellationToken cancellationToken = (CancellationToken)param;



            while (true)
            {
                Console.WriteLine("zzzzZZZZZzzzzZZZZZzz");
                //Task.Delay(50);
                Thread.Sleep(50);
                if (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
        }
    }
}
