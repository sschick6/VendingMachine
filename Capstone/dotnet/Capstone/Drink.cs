using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Drink : Item
    {
        public Drink(string itemName, decimal itemPrice, string itemType, int inventoryCount) : base(itemName, itemPrice, itemType, inventoryCount)
        {

        }
        public override void FunMessage()
        {
            Console.WriteLine("\nGlug Glug, Yum!");
        }
    }
}
