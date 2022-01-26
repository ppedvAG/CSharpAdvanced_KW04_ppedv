using System;

namespace RecordSample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonRecord personRecord1 = new PersonRecord(1, "Mario Bart");
            PersonRecord personRecord2 = new PersonRecord(1, "Mario Bart");

            PersonClass myPerson1Class = new PersonClass(1, "Helge Schneider");
            PersonClass myPerson2Class = new PersonClass(1, "Helge Schneider");


            #region Class vs Record  -> == Operator 
            
            if (myPerson1Class == myPerson2Class)
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class == myPerson2Class -> ungleich");
            }


            if (personRecord1 == personRecord2)
            {
                Console.WriteLine("personRecord1 == personRecord2 -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1 == personRecord2 -> ungleich");
            }



            
            if (myPerson1Class.Equals(myPerson2Class))
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> gleich");
            }
            else
            {
                Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> ungleich");
            }

            if (personRecord1.Equals(personRecord1))
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> gleich");
            }
            else
            {
                Console.WriteLine("personRecord1.Equals(personRecord2) -> ungleich");
            }

            #endregion


            //Die Dekonstruktion
            (int id, string name) = personRecord1; //Dekonstruktion per Default mit dabei 



            //Records mit With 

            Person person1 = new("Nancy", "Davolio") { PhoneNumbers = new string[2] { "1234", "5678" } };


            //person1.FirstName = "Test"; geht nicht wegen init 
            Person person2 = person1 with { FirstName = "John" };



        }
    }

    #region Record Vs Class
    public record PersonRecord(int Id, string Name);

    public class PersonClass
    {
        public PersonClass(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
    #endregion

    public record Person(string FirstName, string LastName)
    {
        public string[] PhoneNumbers { get; init; } //init -> kann nur werte beim Konstruktor annehmen

        public string Haribo { get; set; }
    }

    public abstract record PersonBase(string FirstName, string LastName);


    public record Teacher(string FirstName, string LastName, int Grade)
        : PersonBase(FirstName, LastName);



}
