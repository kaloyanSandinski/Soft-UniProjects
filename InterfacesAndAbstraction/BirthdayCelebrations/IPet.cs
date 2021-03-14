using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IPet : IBirthday
    {
        public string Name { get; set; }
    }
}
