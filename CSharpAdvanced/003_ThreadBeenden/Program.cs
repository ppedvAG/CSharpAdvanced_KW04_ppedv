using System;
using System.Threading;

namespace _003_ThreadBeenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwas_Beispiel1);
            thread.Start();

            Thread.Sleep(3000);
            thread.Interrupt();

            Console.WriteLine("Ready");
            Console.ReadLine();
        }


        //Methode benötigt 10 Sekunden, bis diese fertig durchgelaufen ist 
        private static void MachEtwas_Beispiel1()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("zzzZZZzzzzzZZZZzzz");
                    Thread.Sleep(200);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
