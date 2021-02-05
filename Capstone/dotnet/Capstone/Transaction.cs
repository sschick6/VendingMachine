using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Transaction
    {
        public static decimal CurrentMoney { get; set; }
        public static decimal MachineBalance { get; set; }
        public static bool isPurchasing { get; set; }
        public static Dictionary<string, Item> PurchaseMenu(Dictionary<string, Item> inventoryDict)
        {
            isPurchasing = true;
            while (isPurchasing) 
            {
                Console.WriteLine("(1) Feed money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine($"\nCurrent money provided: {CurrentMoney:C2}");
                string purchaseSelection = Console.ReadLine();
                Console.Clear();
                PurchaseFunctions(purchaseSelection, inventoryDict);
            }
            return inventoryDict;
        }

        public static Dictionary<string, Item> PurchaseFunctions(string selection, Dictionary<string, Item> inventoryDict)
        {
            if (selection == "1")
            {
                Console.WriteLine("Please enter bills:");
                Console.WriteLine("(1) - $1.00");
                Console.WriteLine("(2) - $2.00");
                Console.WriteLine("(5) - $5.00");
                Console.WriteLine("(10) - $10.00");
                string billSelect = Console.ReadLine();
                AddMoney(billSelect);
                Console.Clear();
            }
            else if (selection == "2") 
            {
                Console.WriteLine("ItemCode Price Remaining");
                foreach (KeyValuePair<string, Item> things in inventoryDict)
                {
                    decimal i = things.Value.ItemPrice;
                    int invCount = things.Value.InventoryCount;
                    string n = things.Value.ItemName;
                    if (invCount == 0)
                    {
                        Console.WriteLine($"{things.Key}       ---- SOLD OUT");
                    }
                    else
                    {
                        Console.WriteLine($"{things.Key}       {i}  {invCount} {n}");
                    }
                }
                string productSelect = Console.ReadLine().ToUpper();
                Console.Clear();
                if (inventoryDict.ContainsKey(productSelect) && inventoryDict[productSelect].InventoryCount > 0 && CurrentMoney >= inventoryDict[productSelect].ItemPrice)
                {
                    CurrentMoney -= inventoryDict[productSelect].ItemPrice;
                    MachineBalance += inventoryDict[productSelect].ItemPrice;
                    inventoryDict[productSelect].InventoryCount--;      //here decreasing inventory number by 1
                    inventoryDict[productSelect].ItemSold++;            //at same point, documenting increase in items sold
                    Item a = inventoryDict[productSelect];
                    Console.WriteLine("Dispensing Item...");
                    Console.WriteLine($"\n{a.ItemName} {a.ItemPrice} and you have {CurrentMoney:C2} remaining");
                    TextPrompts.FunMessage(a.ItemType);
                    Console.ReadLine();
                    Console.Clear();
                    string purchaseCode = a.ItemName + " " + productSelect.ToUpper();
                    VendLog.Log(purchaseCode, a.ItemPrice, MachineBalance);
                }
                else if (inventoryDict.ContainsKey(productSelect) && inventoryDict[productSelect].InventoryCount > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Not enough money has been tendered for this transaction!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (inventoryDict.ContainsKey(productSelect))
                {
                    Console.Clear();
                    Console.WriteLine("Product selected is out of stock");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Selection");
                    Console.ReadLine();
                    Console.Clear();
                }

            }
            else if (selection == "3")
            {
                ChangeMaker(CurrentMoney);
                isPurchasing = false;
            }

            return inventoryDict;
        }
        public static void AddMoney(string billSelect)
        {
            if (billSelect == "1")
            {
                CurrentMoney++;
                VendLog.Log("FEED MONEY", 1, MachineBalance);
            }
            else if(billSelect == "2")
            {
                CurrentMoney += 2;
                VendLog.Log("FEED MONEY", 2, MachineBalance);
            }
            else if(billSelect == "5")
            {
                CurrentMoney += 5;
                VendLog.Log("FEED MONEY", 5, MachineBalance);
            }
            else if (billSelect == "10")
            {
                CurrentMoney += 10;
                VendLog.Log("FEED MONEY", 10, MachineBalance);
            }
            else
            {
                Console.WriteLine("Please enter a valid amount");
            }
        }
        public static void ChangeMaker(decimal leftOverMoney)
        {
            Console.WriteLine($"Your change is {CurrentMoney:C2}\n");
            decimal tempCurrent = CurrentMoney * 100;
            string tempChange = (tempCurrent).ToString();
            int change;

            if (tempCurrent == 0)
            {
                change = 0;
            }
            else
            {
                tempChange = tempChange.Substring(0, tempChange.Length - 3);
                change = int.Parse(tempChange);
            }

            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            if (change >= 25 && change % 25 == 0)
            {
                quarters = change / 25;
            }
            else if (change >= 25 && (change % 25) % 10 == 0)
            {
                quarters = change / 25;
                dimes = (change % 25) / 10;
            }
            else if (change >= 25 && ((change % 25) % 10) % 5 == 0)
            {
                quarters = change / 25;
                dimes = (change % 25) / 10;
                nickels = ((change % 25) % 10) / 5;
            }
            else if (change >= 10 && change % 10 == 0)
            {
                dimes = change / 10;
            }
            else if (change >= 10 && (change % 10) % 5 == 0)
            {
                dimes = change / 10;
                nickels = (change % 10) / 5;
            }
            else if (change >= 5 && change % 5 == 0)
            {
                nickels = change / 5;
            }
            Console.WriteLine($"{quarters} Quarters dispensed");
            Console.WriteLine($"{dimes} Dimes dispensed");
            Console.WriteLine($"{nickels} Nickels dispensed");
            Console.ReadLine();
            Console.Clear();
            VendLog.Log("GIVE CHANGE", CurrentMoney, 0);
            CurrentMoney = 0;
        }
    }
}
