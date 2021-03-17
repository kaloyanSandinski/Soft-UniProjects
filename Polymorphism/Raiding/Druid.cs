using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Druid : BaseHero
    {
        private const int constPower = 80;

        public Druid(string name) 
            : base(name, constPower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {Name} healed for {Power}";
        }
    }
}
    