using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public static class Cart
    {
        public static Dictionary<GroceryItem, int> CartItems { get; set; } = new Dictionary<GroceryItem, int>();

        public static bool AddItem(GroceryItem item, int qty)
        {
            CartItems.Add(item, qty);
            return true;
        }

        public static bool DeleteItem(GroceryItem item, int qty)
        {
            //TODO: write an algorithm that removes specified qty from the cart for item
            return false;
        }

        public static  Dictionary<GroceryItem, int> ListCartItems()
        {
            return CartItems;
        }
    }
}
