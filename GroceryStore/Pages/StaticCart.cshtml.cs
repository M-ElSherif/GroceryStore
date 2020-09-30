using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace GroceryStore.Pages
{
    public class StaticCartModel : PageModel
    {
        [BindProperty]
        public List<CartItem> CartItems { get; set; }
        [BindProperty]
        public CartItem CurrentCartItem { get; set; }
        [BindProperty]
        public int NewQty { get; set; }
        [BindProperty]
        public int CurrentIndex { get; set; }
        public double TotalCost { get; set; }
        

        public void OnGet()
        {
            this.CartItems = Cart.GetCartItems();
            this.TotalCost = this.CalcTotalCost();
        }

        public IActionResult OnPostUpdate()
        {
            int index = this.GetGroceryItemIndex(CurrentCartItem.GroceryItem);
            Cart.CartItems[index].Quantity = this.NewQty;
            return RedirectToPage("StaticCart");
        }

        public int GetGroceryItemIndex(GroceryItem item)
        {
            Cart.GetGroceryItemAndIndex(item, out int index, out GroceryItem groceryItem);
            return index;
        }

        public int GetQuantity(GroceryItem item)
        {
            return Cart.GetQuantity(item);
        }

        public double CalcTotalCost()
        {
            foreach (CartItem item in this.CartItems)
            {
                TotalCost += (item.GroceryItem.Price* item.Quantity);
            }
            return TotalCost;
        }
    }
}
