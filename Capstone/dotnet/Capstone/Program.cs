using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Item> inventoryDict = Inventory.InventoryLoad();

            /// <summary>
            /// Create variable and while loop to keep program running
            /// </summary>

            bool appIsRunning = true;
            while (appIsRunning)
            {
                /// <summary>
                /// Call MainMenu and set logic to call next information
                /// </summary>
                
                TextPrompts.MainMenu();
                string menuSelection = Console.ReadLine();
                Console.Clear();
                if(menuSelection == "3")
                {
                    appIsRunning = false;
                    break;
                }
                else if (menuSelection == "2")
                {
                    //Transaction.PurchaseMenu();
                    inventoryDict = Transaction.PurchaseMenu(inventoryDict);
                }
                else if (menuSelection == "1")
                {
                    TextPrompts.MainMenuSelection1(inventoryDict);
                }
                else if (menuSelection == "4")
                {
                    SalesReport.LogSales(inventoryDict);    //pass dictionary into LogSales. LogSales loop through and churn out dictionary
                }
                else
                {
                    Console.WriteLine("Invalid selection - please try again");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
