using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace GroceryStore.Models
{
    public class CartItem
    {
        public GroceryItem GroceryItem { get; set; }
        public int Quantity { get; set; }

        public CartItem()
        {

        }

        public CartItem(GroceryItem item, int quantity)
        {
            GroceryItem = item;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            return obj is CartItem item &&
                   EqualityComparer<GroceryItem>.Default.Equals(GroceryItem, item.GroceryItem);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GroceryItem);
        }
    }
}
