using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;




namespace _009_AsyncAwait_Sample
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            await DoSomethingAsync();
        }

        public static async Task DoSomethingAsync()
        {
            //Mit Task
            Task<string> task = Task.Run(DayTime);

            Task myTask = task.ContinueWith(t => ShowDayTime(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            myTask.Wait(); //Callback-Mechanismus 


            string thecoolerReturnValue = await Task.Run(DayTime);
            await Task.Run(() => ShowDayTime(thecoolerReturnValue));

            string conStr = "";
            //Weitere Szenarien 
            SqlConnection sqlConnection = new SqlConnection(conStr);
            await sqlConnection.OpenAsync();

            SqlCommand sqlCommand = new SqlCommand("Select * Test", sqlConnection);
            Task<int> taskWithRreturnValue = sqlCommand.ExecuteNonQueryAsync();
            taskWithRreturnValue.Wait();
            int result = taskWithRreturnValue.Result;


            int result2 = await sqlCommand.ExecuteNonQueryAsync();
        }

        public static string DayTime()
        {
            DateTime date = DateTime.Now;

            return date.Hour > 17
                ? "evening"
                : date.Hour > 12
                ? "afternoon"
                : "morning";
        }

        public static void ShowDayTime(string result)
        {
            Console.WriteLine(result);
        }
    }
}
