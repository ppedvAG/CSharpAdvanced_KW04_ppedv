using System;
using System.Threading;

namespace _005_ThreadWithCallback
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadWithState tws = new ThreadWithState("Hallo liebe Teilnehmer", 111, new ExampleCallback(ResultCallback));

            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
            Console.WriteLine("Main Thread macht irgendwas anderes");

            t.Join();
            Console.WriteLine("Unabhängiger Thread ist jetzt mit seiner Arbeit fertig geworden");

            Console.ReadLine();
        }

        public static void ResultCallback(MyReturnObject myReturnObject)
        {
            Console.WriteLine($"Rückgabewerte -> {myReturnObject.Zahl} {myReturnObject.Text}");
        }
    }

    public delegate void ExampleCallback(MyReturnObject myReturnObject);

    public class ThreadWithState
    {
        private string myStringText;
        private int myNumberValue;
        private ExampleCallback callback;

        public ThreadWithState(string text, int number, ExampleCallback callbackDelegate)
        {
            callback = callbackDelegate;
            myStringText = text;
            myNumberValue = number; 
        }


        public void ThreadProc()
        {
            Console.WriteLine(myStringText);
            Console.WriteLine(myNumberValue);

           //Mach etwas in dem Thread 


            MyReturnObject myReturnObject = new MyReturnObject();
            myReturnObject.Text = myStringText;
            myReturnObject.Zahl = myNumberValue;


            if (callback != null)
                callback(myReturnObject);
        }

    }


    public class MyReturnObject
    {
        public MyReturnObject()
        {
        }

        public string Text { get; set; }
        public int Zahl { get; set; }

    }
}
