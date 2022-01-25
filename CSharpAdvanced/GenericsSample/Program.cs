using System;
using System.Collections.Generic;

namespace GenericsSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Liste verwenden intern ein T[] von 4 Feldern, wenn diese 4 Felder befüllt sind, verdoppelt er das interne array um das doppelte
            IList<string> nameList = new List<string>();
            nameList.Add("Harry Weinfuhrt");

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "Karl May");
            dict.Add(new KeyValuePair<int, string>(2, "Steven King"));

            if (dict.Keys.Contains(2))
            {
                Console.WriteLine("Id 2 ist schon vergeben");
            }

            if (dict.Values.Contains("Karl May"))
            {
                Console.WriteLine("Karl May ist schon vorhanden");
            }



            foreach (KeyValuePair<int, string> kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} \t {kvp.Value}");
            }




            DataStore<string> dataStore = new DataStore<string>();
            dataStore.AddOrUpdate(0, "Harry");
            dataStore.AddOrUpdate(1, "Hannes");
            dataStore.AddOrUpdate(1, "Klaas");

            dataStore.DisplayDefault<DateTime>();
            dataStore.DisplayDefault<string>();
            dataStore.DisplayDefault<float>();
        }
    }


    public class DataStore<T>
    {
        private T[] _data = new T[10];

        public T[] Data
        {
            get => _data;
            set => _data = value;
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T); //defaultwert von T (null, 0, string.Empty) -> in C# 6 -> private string vorname = default!;
        }


        public void DisplayDefault<MyType>()
        {
            MyType item1 = default!;
            MyType item = default(MyType);
            Console.WriteLine($"Default value of {typeof(MyType)} is {(item == null ? "null" : item.ToString())}.");
        }
    }
}
