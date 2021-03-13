using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : Phone, IBrowseble
    {
        public override string CallOtherPhones(string number)
        {
            Validator.ThrowIfNumberIsInvalid(number);

            return $"Calling... {number}";
        }

        public string BrowseInWeb(string url)
        {
            if (url.Any(x=>char.IsDigit(x)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }
    }
}