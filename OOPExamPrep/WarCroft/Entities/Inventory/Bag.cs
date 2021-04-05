using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int load;
        private int capacity = 100;
        private ICollection<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                capacity = value;
            }
        }

        public int Load
        {
            get
            {
                foreach (var item in items)
                {
                    load += item.Weight;
                }

                return load;
            }
        }

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>) items;
        public void AddItem(Item item)
        {
            if (Load+item.Weight>Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count==0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = Items.FirstOrDefault(i => i.GetType().Name == name);
            if (item==null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(item);
            return item;
        }
    }
}
