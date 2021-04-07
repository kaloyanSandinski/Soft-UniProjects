using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.
        private double health;
        private double armor;
        private string name;
        private double baseHealth;
        private double baseArmor;
        private double abilityPoints;
        private Bag bag;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

        public bool IsAlive { get; set; } = true;

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value>=0&&value<=BaseHealth)
                {
                    health = value;
                }
                else
                {
                    health = 0;
                }
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth
        {
            get
            {
                return baseHealth;
            }
            private set
            {
                if (value>0&&value<=100)
                {
                    baseHealth = value;
                }
            }
        }

        public double BaseArmor
        {
            get
            {
                return baseArmor;
            }
            private set
            {
                baseArmor = value;
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            private set
            {
                if (armor<0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints
        {
            get
            {
                return abilityPoints;
            }
            private set
            {
                abilityPoints = value;
            }
        }

        public Bag Bag
        {
            get
            {
                return bag;
            }
            set
            {
                bag = value;
            }
        }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void IncreaseHealth()
        {
            Health += 20;
        }

        public void DecreaseHealth()
        {
            Health -= 20;
        }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                double hitPointsLeft = 0;
                if (hitPoints-Armor>0)
                {
                    hitPointsLeft = hitPoints - Armor;
                    Armor = 0;

                    if (hitPointsLeft > 0)
                    {
                        Health -= hitPointsLeft;
                    }
                }
                else if (hitPoints-Armor<=0)
                {
                    Armor -= hitPoints;
                }


                if (Health<=0)
                {
                    Health = 0;
                    IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                if (item.GetType().Name == "FirePotion")
                {
                    FirePotion itemFirePotion = (FirePotion) item;
                    itemFirePotion.AffectCharacter(this);
                }
                else
                {
                    HealthPotion itemHealthPotion = (HealthPotion) item;
                    itemHealthPotion.AffectCharacter(this);
                }
            }
        }
    }
}