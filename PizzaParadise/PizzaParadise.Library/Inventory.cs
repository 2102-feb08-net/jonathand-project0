using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParadise.Library
{
    public class Inventory
    {
        public Store InvetoryStore { get; set; }
        public List<InventoryEntry> InventoryEntries { get; set; }
        
        public Inventory()
        {
            InventoryEntries = new List<InventoryEntry>();
        }

        public void AddToInventory(Product p, int amount)
        {
            var entry = new InventoryEntry(p, amount);
            InventoryEntries.Add(entry);
        }
        public void RemoveFromInventory(string name, int amount)
        {
            for (int i = 0; i < InventoryEntries.Count; i++)
            {
                if (InventoryEntries[i].EntryProduct.ItemName == name)
                {
                    if (InventoryEntries[i].Quantity < amount)
                    {
                        throw new ArgumentException("Amount is more than what is in the inventory.", nameof(amount));
                    }
                    else
                    {
                        InventoryEntries[i].Quantity -= amount;
                    }
                }
            }
        }

        //public InventoryEntry GetInventoryEntry(string name)
        //{
        //    InventoryEntry e = new InventoryEntry();

        //    foreach(InventoryEntry entry in InventoryEntries)
        //    {
        //        entry.EntryProduct.ItemName = name;
        //        e = entry;
        //    }
        //    return e;
        //}
    }
}
