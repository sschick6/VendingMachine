using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Chip : Item
    {
        public Chip(string itemName, decimal itemPrice, string itemType, int inventoryCount) : base(itemName,itemPrice, itemType, inventoryCount)
        {

        }
        public override void FunMessage()
        {
            Console.WriteLine("\nCrunch Crunch, Yum!");
        }
    }
}
