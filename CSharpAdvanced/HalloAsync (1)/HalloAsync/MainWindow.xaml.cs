using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HalloAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartOhne(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(400);
                pb1.Value = i;
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.IsEnabled = false;

            Task.Run(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(40);
                        //pb1.Value = i;
                        pb1.Dispatcher.Invoke(() => pb1.Value = i);
                    }

                    btn.Dispatcher.Invoke(() => btn.IsEnabled = true);
                });
        }

        private void StartTaskMitTS(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.IsEnabled = false;
            TaskScheduler ts = TaskScheduler.FromCurrentSynchronizationContext();
            cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(40);
                    Task.Factory.StartNew(() => pb1.Value = i, cts.Token, TaskCreationOptions.None, ts);

                    if (cts.IsCancellationRequested)
                        break;
                }
                Task.Factory.StartNew(() => btn.IsEnabled = true, CancellationToken.None, TaskCreationOptions.None, ts);

            }, cts.Token);

        }
        CancellationTokenSource cts = null;
        private void Abort(object sender, RoutedEventArgs e)
        {
            cts?.Cancel();
        }

        private async void StartAA(object sender, RoutedEventArgs e)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    await Task.Delay(40);
            //    pb1.Value = i;
            //}

            string conString = "Server=.;Database=Northwind;Trusted_Connection=true;";
            using (var con = new SqlConnection(conString))
            {
                await con.OpenAsync();
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "WAITFOR DELAY '00:00:10';SELECT * FROM Customers;";
                    using (var reader = await cmd.ExecuteReaderAsync())
                        while (await reader.ReadAsync())
                        {
                            lb1.Items.Add(reader[1]);
                        }
                }
            }
        }

        private async void StartOldAndSlow(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(MeinAlteMethodeAsync(4).ToString());
            MessageBox.Show((await MeinAlteMethodeAsync(4)).ToString());
        }

        public Task<long> MeinAlteMethodeAsync(int zahl)
        {
            return Task.Run(() => MeinAlteMethode(zahl));
        }

        public long MeinAlteMethode(int zahl)
        {
            Thread.Sleep(5000);
            return zahl * 743;
        }
    }
}
