using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : Phone
    {
        public override string CallOtherPhones(string number)
        {
           Validator.ThrowIfNumberIsInvalid(number);

           return $"Dialing... {number}";
        }
    }
}
