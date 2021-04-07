using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Character> characterParty;
        private ICollection<Item> itemPool;
        public WarController()
        {
            characterParty = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];
            Character character;
            if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            characterParty.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item;
            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            itemPool.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            string itemName = String.Empty;
            Character charecter = characterParty.FirstOrDefault(c => c.Name == characterName);
            if (itemPool.Any())
            {
                itemName = itemPool.Last().GetType().Name;
                if (charecter != null)
                {
                    charecter.Bag.AddItem(itemPool.Last());
                    itemPool.Remove(itemPool.Last());
                }
                else
                {
                    throw new ArgumentException($"Character {characterName} not found!");
                }
            }
            else
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            return $"{characterName} picked up {itemName}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = characterParty.FirstOrDefault(c => c.Name == characterName);
            if (character != null)
            {
                character.UseItem(character.Bag.GetItem(itemName));
            }
            else
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return $"{character.Name} used {itemName}.";
        }

        public string GetStats()
        {
            ICollection<Character> outputCharacters = characterParty.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var outputCharacter in outputCharacters)
            {
                string status = String.Empty;
                if (outputCharacter.IsAlive)
                {
                    status = "Alive";
                }
                else
                {
                    status = "Dead";
                }

                sb.AppendLine(
                    $"{outputCharacter.Name} - HP: {outputCharacter.Health}/{outputCharacter.BaseHealth}, AP: {outputCharacter.Armor}/{outputCharacter.BaseArmor}, Status: {status}");
            }

            return String.Format(sb.ToString().TrimEnd());
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            Warrior attackerCharacter = (Warrior)characterParty.FirstOrDefault(c => c.Name == attackerName);
            Character receiverCharacter = characterParty.FirstOrDefault(c => c.Name == receiverName);
            string output = String.Empty;

            if (attackerCharacter == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if (attackerCharacter.IsAlive)
            {
                if (receiverCharacter.IsAlive == false)
                {
                    throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
                }
                else
                {
                    attackerCharacter.Attack(receiverCharacter);
                }
            }
            else
            {
                throw new ArgumentException($"{attackerCharacter.Name} cannot attack!");
            }

            output = $"{attackerName} attacks {receiverName} for {attackerCharacter.AbilityPoints} hit points! {receiverName} has {receiverCharacter.Health}/{receiverCharacter.BaseHealth} HP and {receiverCharacter.Armor}/{receiverCharacter.BaseArmor} AP left!";
            if (receiverCharacter.IsAlive == false)
            {
                output += $"{Environment.NewLine}{receiverCharacter.Name} is dead!";
            }

            return String.Format(output);
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            Priest healerCharacter = (Priest)characterParty.FirstOrDefault(c => c.Name == healerName);
            Character healingReceiverCharacter = characterParty.FirstOrDefault(c => c.Name == healingReceiverName);
            string output = String.Empty;

            if (healerCharacter == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (healingReceiverCharacter == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (healerCharacter.IsAlive && healingReceiverCharacter.IsAlive)
            {
                if (healingReceiverCharacter.IsAlive == false)
                {
                    throw new InvalidOperationException("Must be alive to perform this action!");
                }
                else
                {
                    healerCharacter.Heal(healingReceiverCharacter);
                }
            }
            else
            {
                throw new ArgumentException($"{healerCharacter.Name} cannot heal!");
            }

            return String.Format($"{healerCharacter.Name} heals {healingReceiverCharacter.Name} for {healerCharacter.AbilityPoints}! {healingReceiverCharacter.Name} has {healingReceiverCharacter.Health} health now!");
        }
    }
}
