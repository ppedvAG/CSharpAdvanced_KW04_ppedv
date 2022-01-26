using System;
using System.Dynamic;

namespace DynamicObjectSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic myObj = new ExpandoObject();
            myObj.Vorname = "Max";
            myObj.Nachname = "Moritz";

            Console.WriteLine(myObj.Vorname);
            Console.WriteLine(myObj.Nachname);
        }
    }
}
