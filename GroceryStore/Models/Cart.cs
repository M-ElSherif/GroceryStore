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

        public static Dictionary<GroceryItem, int> GetCartItems()
        {
            return CartItems;
        }

        public static Boolean AddToCart(GroceryItem item, int qty)
        {
            if (SearchCart(item))
            {
                CartItems[item] += qty;
            }
            else
            {
                CartItems.Add(item, qty);
            }
            return true;
        }

        public static Boolean RemoveFromCart(GroceryItem item, int qty)
        {
            return false;
        }

        public static Boolean SearchCart(GroceryItem item)
        {
            return CartItems.ContainsKey(item);
        }
    }
}
