using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002a_Task_Beenden
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var tokenSource2 = new CancellationTokenSource();
            CancellationToken token = tokenSource2.Token;

            var task = new Task(MethodeInTask, token);
            task.Start();
           
            Thread.Sleep(5000);
            tokenSource2.Cancel();

            // Just continue on this thread, or await with try-catch:
            try
            {
                await task;
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
            }
            finally
            {
                tokenSource2.Dispose();
            }

            Console.ReadKey();
        }


        private static void MethodeInTask(object token)
        {
            CancellationToken ct = (CancellationToken)token;
            
            
            bool moreToDo = true;
            while (moreToDo)
            {
                // Poll on this property if you have to do
                // other cleanup before throwing.
                if (ct.IsCancellationRequested)
                {
                    // Clean up here, then...
                    ct.ThrowIfCancellationRequested();
                }

                Console.WriteLine("zzzZZZzzzZZZzzzZZZ");
            }
        }

    }
}
