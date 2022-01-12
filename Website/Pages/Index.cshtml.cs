using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<TheFlyingSaucer.Data.IOrderItem> Items { get; set; }


        /// <summary>
        /// The name keywords from the search bar
        /// </summary>
        public string SearchTerms { get; set; }

        /// <summary>
        /// Filtered entrees
        /// </summary>
        public IEnumerable<string> Category { get; set; }

        /// <summary>
        /// Minimum amount of calories to be searched for
        /// </summary>
        public int? MinCalories { get; set; }

        /// <summary>
        /// Maximum amount of calories to be searched for
        /// </summary>
        public int? MaxCalories { get; set; }

        /// <summary>
        /// Minimum price to be searched for 
        /// </summary>
        public double? MinPrice { get; set; }

        /// <summary>
        /// Maximum price to be searched for
        /// </summary>
        public double? MaxPrice { get; set; }

        /// <summary>
        /// The model class for the home page
        /// </summary>
        /// <param name="logger"></param>
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets the search results to display on the page
        /// </summary>
        public void OnGet(string searchTerms, IEnumerable<string> category, int? minCalories, int? maxCalories, double? minPrice, double? maxPrice)
        {
            this.SearchTerms = searchTerms;
            this.Category = category;
            this.MinCalories = minCalories;
            this.MaxCalories = maxCalories;
            this.MinPrice = minPrice;
            this.MaxPrice = maxPrice;

            Items = TheFlyingSaucer.Data.Menu.All;
            if(SearchTerms != null)
            {
                Items = Items.Where(item => item.Name.Contains(SearchTerms, StringComparison.InvariantCultureIgnoreCase) || item.Description.Contains(SearchTerms, StringComparison.InvariantCultureIgnoreCase));
            }
            if(Category != null && Category.Count() != 0)
            {
                Items = from item in Items where item is TheFlyingSaucer.Data.Entree && Category.Contains("Entrees")
                        || item is TheFlyingSaucer.Data.Drink && Category.Contains("Drinks")
                        || item is TheFlyingSaucer.Data.Side && Category.Contains("Sides")
                        select item;
            }

            if(MaxCalories != null)
                Items = Items.Where(item => item.Calories <= MaxCalories);
            if(MinCalories != null)
                Items = Items.Where(item => item.Calories >= MinCalories);

            if (MaxPrice != null)
                Items = Items.Where(item => item.Price <= (decimal)MaxPrice);
            if (MinPrice != null)
                Items = Items.Where(item => item.Price >= (decimal)MinPrice);
        }
    }
}
