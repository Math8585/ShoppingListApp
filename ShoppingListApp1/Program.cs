using System;
using System.Collections.Generic;

namespace ShoppingListApp1
{
    internal class Program

    {
        private static Dictionary<string, int> ShoppingList = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nShopping List Menu:");
                Console.WriteLine("1 - Add product to Shopping List");
                Console.WriteLine("2 - Remove product from list");
                Console.WriteLine("3 - Show Shopping List");
                Console.WriteLine("4 - Exit");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nPlease make your choice");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;

                    case "2":
                        RemoveProduct();
                        break;

                    case "3":
                        ShowAllShoppingList();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice, please choose valid option");
                        break;
                }
            }
        }

        private static void AddProduct()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please enter product name");

            string productName = Console.ReadLine().Trim().ToLower();

            Console.WriteLine("Please enter quantity");

            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
            {
                if (ShoppingList.ContainsKey(productName)) {
                    ShoppingList[productName] += quantity;
                } else
                {
                    ShoppingList[productName] = quantity;
                }

                Console.WriteLine($"Added {quantity} x {productName} to Shopping List");
            } else {
                Console.WriteLine("Please enter valid quantity");
            }

        }

        private static void RemoveProduct()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Please enter product name that you want to remove");

            string productName = Console.ReadLine().Trim().ToLower();

           
                if (ShoppingList.ContainsKey(productName))
                {
                    ShoppingList.Remove(productName);
                Console.WriteLine($"{productName} removed from the Shopping List");
            }
                else
                {
                Console.WriteLine($"{productName} is not in the Shopping List");
            }

                
            }


        private static void ShowAllShoppingList()
        {
            if (ShoppingList.Count == 0)
            {
                Console.WriteLine($"Shopping List is empty");

            }

            int number = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Shopping list");
            foreach (var product in ShoppingList) 
            {
                string unit = product.Value > 1 ? "pcs." : "pc.";
                Console.WriteLine($"{number}. {product.Key} - {product.Value}{unit}");
                number++;
            }
        }

    }
}
