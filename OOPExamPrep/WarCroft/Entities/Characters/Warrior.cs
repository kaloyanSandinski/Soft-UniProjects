using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public class Warrior : Character, IAttacker
    {
        //100 Base Health, 50 Base Armor, 40 Ability Points
        private const double baseHealthConst = 100;
        private const double baseArmorConst = 50;
        private const double baseAbilityPoints = 40;


        public Warrior(string name)
            : base(name, baseHealthConst, baseArmorConst, baseAbilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            if (character.IsAlive)
            {
                if (character.Name==this.Name)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }

                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
