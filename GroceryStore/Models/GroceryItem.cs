using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStore.Models
{
    public class GroceryItem
    {
        public string Name { get; set; }
        public string ImageSrc { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }

        public GroceryItem()
        {

        }

        public GroceryItem(GroceryItem groceryItem)
        {
            this.Name = groceryItem.Name;
            this.ImageSrc = groceryItem.ImageSrc;
            this.Price = groceryItem.Price;
            this.Desc = groceryItem.Desc;
        }

        public GroceryItem(string name = "Not Found", string imgsrc = "/images/blank.png", double price = 0.0, string desc = "n/a")
        {
            Name = name;
            ImageSrc = imgsrc;
            Price = price;
            Desc = desc;
        }

        public override bool Equals(object obj)
        {
            return obj is GroceryItem item &&
                   Name == item.Name &&
                   ImageSrc == item.ImageSrc &&
                   Price == item.Price &&
                   Desc == item.Desc;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, ImageSrc, Price, Desc);
        }
    }
}
