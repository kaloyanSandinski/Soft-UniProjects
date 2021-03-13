using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public interface ICitizen : IIdentifiable
    {
            public int Age { get; set; }
            public string Name { get; set; }
    }
}
