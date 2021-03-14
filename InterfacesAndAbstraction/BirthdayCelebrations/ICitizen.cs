using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public interface ICitizen : IIdentifiable, IBirthday
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public string Birthdate { get; set; }
    }
}
