using System;
using System.Threading;

namespace _001_ThreadStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwasInEinemThread); //Thread benötigt den funktionszeiger der jeweiligen Methode
            thread.Start(); //thread wird in seinem eigenen Context geladen

            thread.Join();

            for(int i = 0; i < 100; i++)
                Console.WriteLine("*");


            Console.ReadLine();
        }

        //Diese Methode soll in einem Thread laufen 
        private static void MachEtwasInEinemThread()
        {
            for(int i = 0; i < 100; i++)
                Console.WriteLine("#");
        }
    }
}
