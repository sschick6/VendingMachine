﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Item
    {
        public string ItemName { get; private set; }
        public decimal ItemPrice { get; private set; }
        public string ItemType { get; private set; }
        public int InventoryCount { get; set; }

        public Item(string itemName, decimal itemPrice, string itemType, int inventoryCount)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemType = itemType;
            InventoryCount = inventoryCount;
        }
    }
}
