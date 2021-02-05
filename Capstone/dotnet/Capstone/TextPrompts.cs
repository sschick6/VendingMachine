using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class TextPrompts
    {
        public static void MainMenu()
        {
            /// <summary>
            /// MainMenu display to console 
            /// </summary>
            Console.WriteLine("TE Team Zero Vending Machine");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.WriteLine("\nPlease make your selection and press RETURN");
        }
                public static void MainMenuSelection1(Dictionary<string, Item> inventoryDict)
        {
            Console.WriteLine("ItemCode Price Remaining");
            foreach (KeyValuePair<string, Item> things in inventoryDict)
            {
                decimal i = things.Value.ItemPrice;
                int invCount = things.Value.InventoryCount;
                if (invCount == 0)
                {
                    Console.WriteLine($"{things.Key}       ---- SOLD OUT");
                }
                else
                {
                    Console.WriteLine($"{things.Key}       {i}  {invCount}");
                }
            }
            Console.WriteLine("Press RETURN to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        public static void FunMessage(string itemType)
        {
            if (itemType == "Chip")
            {
                Console.WriteLine("\nCrunch Crunch, Yum!");
            }
            else if (itemType == "Candy")
            {
                Console.WriteLine("\nMunch Munch, Yum!");
            }
            else if (itemType == "Drink")
            {
                Console.WriteLine("\nGlug Glug, Yum!");
            }
            else if (itemType == "Gum")
            {
                Console.WriteLine("\nChew Chew, Yum!");
            }
            else
            {
                Console.WriteLine("Invalid Item");
            }
        }
    }
}
