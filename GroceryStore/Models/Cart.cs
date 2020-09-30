using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public static class Cart
    {
        public static List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public static List<CartItem> GetCartItems()
        {
            return CartItems;
        }

        public static Boolean AddToCart(GroceryItem item, int qty)
        {
            if (SearchCart(item))
            {
                CartItems.Find(cartItem => cartItem.GroceryItem.Equals(item)).Quantity += qty;
            }
            else
            {
                CartItems.Add(new CartItem(item, qty));
            }
            return true;
        }

        public static void GetGroceryItemAndIndex(GroceryItem item, out int index, out GroceryItem groceryItem)
        {
            CartItem cartItem = CartItems.Find(cartitem => cartitem.GroceryItem.Equals(item));
            groceryItem = cartItem.GroceryItem;
            index = CartItems.IndexOf(cartItem);
        }

        public static int GetQuantity(GroceryItem item)
        {
            return CartItems.Find(cartItem => cartItem.Equals(item)).Quantity;
        }

        public static Boolean SearchCart(GroceryItem item)
        {
            return CartItems.Exists(cartItem => cartItem.GroceryItem.Equals(item));
        }
    }
}
