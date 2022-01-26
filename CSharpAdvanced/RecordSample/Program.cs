using System;

namespace RecordSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person p = new Person(1, "Harry", "Weinfurt");


            int Id;
            string FirstName;
            string LastName;

            (Id, FirstName, LastName) = p; //Deconstructor 

            
        }
    }

    public record Person(int Id, string FirstName, string LastName);
}
