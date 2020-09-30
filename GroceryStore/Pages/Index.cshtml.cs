using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using GroceryStore.Models;

namespace GroceryStore.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public int Rating { get; set; }
        [BindProperty]
        public string Feedback { get; set; }
        [BindProperty]
        public List<GroceryItem> Foods { get; set; }

        public void OnGet()
        {
            ViewData["Inventory"] = Inventory.ToList();
            this.Foods = (List<GroceryItem>)ViewData["Inventory"];
        }

        public async Task<IActionResult> OnPostAsync()
        {
            using (StreamWriter writer = new StreamWriter("suggestions.txt", append: true))
            {
                await writer.WriteLineAsync(this.Feedback + " " + this.Rating);
            }
            return Page();
        }

        //TODO: Refactor or remove
        public IActionResult OnPostRating()
        {
            return Page();
        }

    }
}
