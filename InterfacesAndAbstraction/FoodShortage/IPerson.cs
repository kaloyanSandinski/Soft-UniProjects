using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IPerson : IBuyer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
