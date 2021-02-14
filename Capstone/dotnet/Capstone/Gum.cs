using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Gum : Item
    {
        public Gum(string itemName, decimal itemPrice, string itemType, int inventoryCount) : base(itemName, itemPrice, itemType, inventoryCount)
        {

        }
        public override void FunMessage()
        {
            Console.WriteLine("\nChew Chew, Yum!");
        }
    }
}
