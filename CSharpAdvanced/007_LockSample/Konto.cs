using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_LockSample
{
    public static class Konto //Ressourcen-Klasse
    {
        public static decimal Kontostand { get; set; } = 0; //Wenn zwei Thread versuchen gleichzeitig eine Variable zu manipulieren, entsteht ein Dead-Lock
        public static int TransactionId { get; set; } = 0;



        //
        public static object lockObject = new object(); //Ist ein Flag
      
        public static void Einzahlen(decimal betrag)
        {
            try
            {

                lock (lockObject)
                {
                    TransactionId++;
                    Kontostand += betrag;

                    Console.WriteLine($"Id:{TransactionId} \t Kontostand nach dem Einzahlen: {Kontostand}");
                }
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Deadlock juhuuu");
            }
        }

        public static void Abheben (decimal betrag)
        {
            try
            {

                lock (lockObject)
                {
                    TransactionId++;
                    Kontostand -= betrag;

                    Console.WriteLine($"Id:{TransactionId} \t Kontostand nach dem Abhebem: {Kontostand}");
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
