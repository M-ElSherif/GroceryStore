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
        public Dictionary<GroceryItem, int> CartItems { get; set; }
        public double TotalCost { get; set; }

        public void OnGet()
        {
            this.CartItems = Cart.GetCartItems();
            this.TotalCost = this.CalcTotalCost();
        }

        public IActionResult OnPostChange()
        {
            //this.CartItems[]
            return Page();
        }



        public int GetQuantity(GroceryItem item)
        {
            if (this.CartItems.ContainsKey(item))
            {
                return this.CartItems[item];
            }
            return 0;
        }

        public double CalcTotalCost()
        {
            foreach (KeyValuePair<GroceryItem, int> item in this.CartItems)
            {
                TotalCost += (item.Key.Price * item.Value);
            }
            return TotalCost;
        }
    }
}
