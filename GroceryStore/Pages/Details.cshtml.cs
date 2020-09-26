using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace GroceryStore.Pages
{
    public class DetailsModel : PageModel
    {
        public List<GroceryItem> Foods { get; set; }
        [BindProperty]
        public GroceryItem CurrentFood { get; set; }
        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", append: true))
            {
                await writer.WriteLineAsync($"{DateTime.Now} {name}");
            }
            this.Foods = Inventory.ToList();
            this.CurrentFood = this.Foods.
                Find(food => food.Name.ToLower().Equals(name.ToLower()));
            if (this.CurrentFood == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAdd()
        {
            Cart.AddItem(this.CurrentFood, Quantity);
            return Page();
        }

        public double CalcTotalCost()
        {
            return this.Quantity * this.CurrentFood.Price;
        }
    }
}
