using System;
using System.Threading.Tasks;

namespace _004_TaskMitParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new();


            //Task<string> = ein Task, dass ein String-Ergebnis erhält
            //SourceCode -> public class Task<TResult> : Task
            Task<string> task = new Task<string>(() => MachEtwas(katze));
            task.Start();
            task.Wait();

            string result = task.Result; //Bekommen unseren return-Wert (string) aus MachEtwas 



            //via Factory 

            Task<string> task2 = Task.Factory.StartNew(MachEtwas, katze);
            task2.Wait();
            Console.WriteLine(task2.Result);


            //Task.Run 
            Task<string> task3 = Task.Run(() => MachEtwas(katze));
            task3.Wait();
            string result3 = task3.Result;
        }



        private static string MachEtwas(object input)
        {
            if (input is Katze myCat)
            {
                return myCat.Name;
            }

            throw new ArgumentException();
        }
    }


    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
