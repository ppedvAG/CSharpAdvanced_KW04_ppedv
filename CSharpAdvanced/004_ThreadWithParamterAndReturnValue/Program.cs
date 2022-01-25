using System;
using System.Threading;

namespace _004_ThreadWithParamterAndReturnValue
{
    internal class Program
    {
        static string retString = string.Empty;
        static string meinText = "Hello World";

        static void Main(string[] args)
        {


            //Thread thread = new Thread(() => //anonyme Methode
            //{
            //    //Hier befinden wir uns schon im Thread - Kontext
            //    retString = StringToUpper(meinText);
            //});

            Thread thread = new Thread(MethodeInThread);



            thread.Start();
            thread.Join();

            Console.WriteLine(retString);
            Console.ReadLine();
        }


        private static void MethodeInThread()
        {
            retString = StringToUpper(meinText);
        }
        private static string StringToUpper(string param)
        {
            return param.ToUpper();
        }
    }
}
