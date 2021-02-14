using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    abstract class Item
    {
        public string ItemName { get; private set; }
        public decimal ItemPrice { get; private set; }
        public string ItemType { get; private set; }
        public int InventoryCount { get; set; }

        public int ItemSold { get; set; } = 0;

        public decimal ItemSales { get; private set; }

        public Item(string itemName, decimal itemPrice, string itemType, int inventoryCount)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemType = itemType;
            InventoryCount = inventoryCount;
        }
        abstract public void FunMessage();
    }
}
