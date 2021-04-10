using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int comfortConst = 1;
        private const decimal priceConst = 5;

        public Ornament() 
            : base(comfortConst, priceConst)
        {
        }
    }
}
