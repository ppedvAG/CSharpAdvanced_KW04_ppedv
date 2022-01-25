using System;
using System.Threading;

namespace _002_ThreadMitParameterStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Wrapper
            ParameterizedThreadStart parameterized = new ParameterizedThreadStart(MachEtwasInEinemThread);

            Thread t = new Thread(parameterized);
            t.Start(600);

            t.Join();

            for(int i = 0; i <500; i++)
                Console.WriteLine("*");


            Console.ReadLine();
        }


        //Diese Methode soll in einem Thread laufen 
        private static void MachEtwasInEinemThread(object obj) //obj = 600
        {
            if (obj is int until) //wird expliziet in ein int gecastet 
            {
                for (int i =0; i < until; i++)
                    Console.WriteLine(i.ToString() + " #");
            }


            //wenn ein wenig logik mehr -> 
            //if (obj is not Person)
            //    throw new ArgumentException("This object is not supported");
        }
    }

    public class Person
    { 
        public int Id { get; set; } 
        public string Name { get; set; }    
    }

    public class Employee : Person
    {
        public string Company { get; set; }
    }
}
