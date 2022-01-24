using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern_with_abstract_Class
{
    /// <summary>
    /// The Builder abstract class
    /// </summary>
    public abstract class SandwichBuilder
    {
        protected Sandwich sandwich;



        // Gets sandwich instance
        public Sandwich Sandwich
        {
            get
            {
                return sandwich;
            }
        }

        // Abstract build methods
        public abstract void AddBread();
        public abstract void AddMeats();
        public abstract void AddCheese();
        public abstract void AddVeggies();
        public abstract void AddCondiments();

        public void Help()
        {
            Console.WriteLine("Please Call the Support");
        }

        public virtual void AnyLogic()
        {
            Console.WriteLine("la le lu");
            //Macht iregendwas -> 
        }
        
    }
}
