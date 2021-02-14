using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    abstract class Inventory
    {
        
        public static Dictionary<string, Item> InventoryLoad()
        {
            Dictionary<string, Item> inventoryDict = new Dictionary<string, Item>();
            /// <summary>
            /// This method will create items from the inventory document
            /// </summary>
            
            try
            {
                string filePath = Directory.GetCurrentDirectory();
                string fileName = @"vendingmachine.csv";
                string fullPath = Path.Combine(filePath, fileName);
                using(StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        /// <summary>
                        /// In the while loop we are creating a new temporary
                        /// string array to populate values into new Item instances
                        /// </summary>
                        
                        string line = sr.ReadLine();
                        string[] temp = line.Split('|');

                        /// <summary>
                        /// Assign values from the array to a constructor for
                        /// the new item and default the inventory to 5
                        /// </summary>
                        string itemRow = temp[0];
                        string itemName = temp[1];
                        decimal itemPrice = decimal.Parse(temp[2]);
                        string itemType = temp[3];
                        int inventoryCount = 5;

                        if(itemType == "Gum")
                        {
                            Gum gum = new Gum(itemName, itemPrice, itemType, inventoryCount);
                            inventoryDict.Add(itemRow, gum);
                        }
                        else if(itemType == "Drink")
                        {
                            Drink drink = new Drink(itemName, itemPrice, itemType, inventoryCount);
                            inventoryDict.Add(itemRow, drink);
                        }
                        else if (itemType == "Chip")
                        {
                            Chip chip = new Chip(itemName, itemPrice, itemType, inventoryCount);
                            inventoryDict.Add(itemRow, chip);
                        }
                        else if (itemType == "Candy")
                        {
                            Candy candy = new Candy(itemName, itemPrice, itemType, inventoryCount);
                            inventoryDict.Add(itemRow, candy);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return inventoryDict;
        }
    }
}
