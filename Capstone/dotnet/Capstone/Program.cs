using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Create variable and while loop to keep program running
            /// </summary>
            
            bool appIsRunning = true;
            while (appIsRunning)
            {
                /// <summary>
                /// Call InventoryLoad method to read current inventory from file
                /// 
                /// This will be a transparent process that is not displayed to user
                /// until called on by the ViewInventory method
                /// </summary>
                
                // InventoryClass.InventoryLoad();

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
                else
                {
                    TextPrompts.MainMenu();
                    menuSelection = Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
