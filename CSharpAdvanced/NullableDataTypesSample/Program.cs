using System;

namespace NullableDataTypesSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int normalInteger = default(int); //0


            int? nullableInteger = null;

            if (nullableInteger.HasValue)
            {
                Console.WriteLine(nullableInteger.Value);
            }

            nullableInteger = 123;

            if (nullableInteger.HasValue)
            {
                Console.WriteLine(nullableInteger.Value);
            }

            string emptyString = string.Empty; ;

            if(!string.IsNullOrEmpty(emptyString))
            {
                //ist befüllt
                Console.WriteLine(emptyString);
            }


            







        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }    
    }
}
