using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace GroceryStore.Pages
{
    public class StaticCartModel : PageModel
    {
        public Dictionary<GroceryItem, int> CartItems { get; set; }
        
        public void OnGet()
        {
            this.CartItems = Cart.ListCartItems();
        }
    }
}
