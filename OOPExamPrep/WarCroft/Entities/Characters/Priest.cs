using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double baseHealthConst = 50;
        private const double baseArmorConst = 25;
        private const double baseAbilityPointsConst = 40;

        public Priest(string name) 
            : base(name, baseHealthConst, baseArmorConst, baseAbilityPointsConst, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            if (this.IsAlive&&character.IsAlive)
            {
                character.Health += this.AbilityPoints;
            }
        }
    }
}
