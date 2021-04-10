using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int comfortConst = 5;
        private const decimal priceConst = 10;
        public Plant() 
            : base(comfortConst, priceConst)
        {
        }
    }
}
