using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern_with_abstract_Class
{
    public class SandwichMaker
    {
        private SandwichBuilder builder;

        public SandwichMaker(SandwichBuilder builder)
        {
            this.builder = builder;
        }

        public void buildSandwich()
        {
            builder.AddBread();
            builder.AddMeats();
            builder.AddCheese();
            builder.AddVeggies();
            builder.AddVeggies();
            builder.AddCondiments();
        }
    }
}
