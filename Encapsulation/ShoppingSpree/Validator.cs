using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public static class Validator
    {
        public static void ThrowIfStringIsNotValid(string input, string exceptionMessage)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        public static void ThrowIfNumberIsNotValid(decimal input, string exceptionMessage)
        {
            if (input < 0)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
