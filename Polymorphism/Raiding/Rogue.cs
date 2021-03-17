using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Rogue : BaseHero
    {
        private const int constPower = 80;

        public Rogue(string name)
            : base(name, constPower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {Name} hit for {Power} damage";
        }
    }
}
