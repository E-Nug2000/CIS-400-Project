/*
 * Author: Edward Gruver
 * File Name: Menu.cs
 * Purpose: Static class that represents a menu
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Entrees;
using TheFlyingSaucer.Data.Sides;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Enums;
using System.Linq;
using System.IO;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Represents the menu
    /// </summary>
    public static class Menu
    {


        private static List<IOrderItem> itemMenu = new List<IOrderItem>();




        /// <summary>
        /// list of entrees, includes each variation of entree that affects the calories or price
        /// </summary>
        public static IEnumerable<IOrderItem> Entrees
        {
            get
            {
                List<IOrderItem> entrees = new List<IOrderItem>();
                entrees.Add(new CrashedSaucer() { HalfStack = true });
                entrees.Add(new CrashedSaucer());
                entrees.Add(new FlyingSaucer() { HalfStack = true });
                entrees.Add(new FlyingSaucer());
                entrees.Add(new LivestockMutilation() { GravyOnTheSide = true });
                entrees.Add(new LivestockMutilation());
                entrees.Add(new NothingToSeeHere() { SubstituteSausage = true });
                entrees.Add(new NothingToSeeHere());
                entrees.Add(new OuterOmelette());
                entrees.Add(new SpaceScramble());

                return entrees;
            }
        }

        /// <summary>
        /// list of sides, includes each variation of side that affects the calories or price
        /// </summary>
        public static IEnumerable<IOrderItem> Sides
        {
            get
            {
                List<IOrderItem> sides = new List<IOrderItem>();
                sides.Add(new CropCircleOats { Size = Size.Small });
                sides.Add(new CropCircleOats { Size = Size.Medium });
                sides.Add(new CropCircleOats { Size = Size.Large });
                sides.Add(new EvisceratedEggs { Size = Size.Small });
                sides.Add(new EvisceratedEggs { Size = Size.Medium });
                sides.Add(new EvisceratedEggs { Size = Size.Large });
                sides.Add(new GlowingHaystack { Size = Size.Small });
                sides.Add(new GlowingHaystack { Size = Size.Medium });
                sides.Add(new GlowingHaystack { Size = Size.Large });
                sides.Add(new MissingLinks { Size = Size.Small });
                sides.Add(new MissingLinks { Size = Size.Medium });
                sides.Add(new MissingLinks { Size = Size.Large });
                sides.Add(new TakenBacon { Size = Size.Small });
                sides.Add(new TakenBacon { Size = Size.Medium });
                sides.Add(new TakenBacon { Size = Size.Large });
                sides.Add(new YoureToast { Size = Size.Small });
                sides.Add(new YoureToast { Size = Size.Medium });
                sides.Add(new YoureToast { Size = Size.Large });
                return sides;
            }
        }

        /// <summary>
        /// list of drinks, includes each variation of drink that affects the calories or price
        /// </summary>
        public static IEnumerable<IOrderItem> Drinks
        {
            get
            {
                List<IOrderItem> drinks = new List<IOrderItem>();
                drinks.Add(new LiquifiedVegetation { Size = Size.Small, JuiceFlavor = JuiceFlavor.Apple });
                drinks.Add(new LiquifiedVegetation { Size = Size.Medium, JuiceFlavor = JuiceFlavor.Apple });
                drinks.Add(new LiquifiedVegetation { Size = Size.Large, JuiceFlavor = JuiceFlavor.Apple });
                drinks.Add(new LiquifiedVegetation { Size = Size.Small, JuiceFlavor = JuiceFlavor.Cranberry });
                drinks.Add(new LiquifiedVegetation { Size = Size.Medium, JuiceFlavor = JuiceFlavor.Cranberry });
                drinks.Add(new LiquifiedVegetation { Size = Size.Large, JuiceFlavor = JuiceFlavor.Cranberry });
                drinks.Add(new LiquifiedVegetation { Size = Size.Small, JuiceFlavor = JuiceFlavor.Grape });
                drinks.Add(new LiquifiedVegetation { Size = Size.Medium, JuiceFlavor = JuiceFlavor.Grape });
                drinks.Add(new LiquifiedVegetation { Size = Size.Large, JuiceFlavor = JuiceFlavor.Grape });
                drinks.Add(new LiquifiedVegetation { Size = Size.Small, JuiceFlavor = JuiceFlavor.Orange });
                drinks.Add(new LiquifiedVegetation { Size = Size.Medium, JuiceFlavor = JuiceFlavor.Orange });
                drinks.Add(new LiquifiedVegetation { Size = Size.Large, JuiceFlavor = JuiceFlavor.Orange });
                drinks.Add(new LiquifiedVegetation { Size = Size.Small, JuiceFlavor = JuiceFlavor.Tomato });
                drinks.Add(new LiquifiedVegetation { Size = Size.Medium, JuiceFlavor = JuiceFlavor.Tomato });
                drinks.Add(new LiquifiedVegetation { Size = Size.Large, JuiceFlavor = JuiceFlavor.Tomato});
                drinks.Add(new SaucerFuel { Size = Size.Small});
                drinks.Add(new SaucerFuel { Size = Size.Medium });
                drinks.Add(new SaucerFuel { Size = Size.Large });
                drinks.Add(new SaucerFuel { Size = Size.Small, Decaf = true });
                drinks.Add(new SaucerFuel { Size = Size.Medium, Decaf = true });
                drinks.Add(new SaucerFuel { Size = Size.Large, Decaf = true });
                drinks.Add(new Water());
                return drinks;
            }
        }

        public static IEnumerable<IOrderItem> FullMenu
        {
            get
            {
                List<IOrderItem> menu = new List<IOrderItem>();
                foreach (IOrderItem item in Entrees) menu.Add(item);
                foreach (IOrderItem item in Drinks) menu.Add(item);
                foreach (IOrderItem item in Sides) menu.Add(item);
                foreach (IOrderItem item in menu) itemMenu.Add(item);
                return menu;

            }
        }




        public static string[] Categories
        {
            get => new string[]
            {
                "Entrees",
                "Drinks",
                "Sides",
            };
        }

        public static IEnumerable<IOrderItem> All { get 
            {
                List<IOrderItem> items = new List<IOrderItem>();
                items.AddRange(Entrees);
                items.AddRange(Sides);
                items.AddRange(Drinks);
                return items;

            }
        }

        /// <summary>
        /// Searches the menu for the item specified
        /// </summary>
        /// <param name="item">the item being searched for</param>
        /// <param name="terms">the terms inputted</param>
        /// <returns>Collection of items searched for</returns>
        public static IEnumerable<IOrderItem> Search(IEnumerable<IOrderItem>items, string terms)
        {
            List<IOrderItem> results = new List<IOrderItem>();

            if (terms == null) return items;

            string[] brokenTerms = terms.Split(' ');

            foreach (IOrderItem menuitem in FullMenu)
            {
                foreach (string str in brokenTerms)
                {
                    if (menuitem.Name != null && menuitem.Description != null)
                    {
                        if (menuitem.Name.ToLower().Contains(str.ToLower()) || menuitem.Description.ToLower().Contains(str.ToLower()))
                        {
                            results.Add(menuitem);
                            break;
                        }
                    }

                }
            }
            
            return results;
        }

        //IEnumerable<IOrderItem> item,

        /// <summary>
        /// Filters the provided collection of menu items by category
        /// </summary>
        /// <param name="item">The items being searched for</param>
        /// <param name="category">the category of the items we want</param>
        /// <returns>collection of items that made it through the filter</returns>
        public static IEnumerable<IOrderItem> FilterByCategory( IEnumerable<string> categories)
        {
            
            List<IOrderItem> results = new List<IOrderItem>();

            foreach(string category in categories)
            {
                if (category.Contains("Entrees"))
                {
                    foreach(IOrderItem menuItem in Entrees)
                    {
                        results.Add(menuItem);
                    }
                }
                if (category.Contains("Sides"))
                {
                    foreach (IOrderItem menuItem in Sides) results.Add(menuItem);
                }
                if (category.Contains("Drinks"))
                {
                    foreach (IOrderItem menuItem in Drinks) results.Add(menuItem);
                }
            }
            return results;
        }
        
        /// <summary>
        /// Filters the provided collection of menu items by a range of calories
        /// </summary>
        /// <param name="item">the item being searched for</param>
        /// <param name="min">the minimum calorie value</param>
        /// <param name="max">the maximum calorie calue</param>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> items, int? min, int? max)
        {
            if (min == null && max == null) return items;

            List<IOrderItem> results = new List<IOrderItem>();

            if(min == null)
            {
                foreach(IOrderItem item in items)
                {
                    if (item.Calories <= max) results.Add(item);
                }
                return results;
            }

            if(max == null)
            {
                foreach(IOrderItem item in items)
                {
                    if (item.Calories >= min) results.Add(item);
                }
                return results;
            }

            foreach(IOrderItem item in items)
            {
                if (item.Calories >= min && item.Calories <= max) results.Add(item);
            }
            return results;


        }

        /// <summary>
        /// Filters the provided colleciton of menu items by range of price
        /// </summary>
        /// <param name="item">The item being searched for</param>
        /// <param name="min">The minimum price value</param>
        /// <param name="max">The maximum price value</param>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> items, double? min, double? max)
        {
            if (min == null && max == null) return items;

            List<IOrderItem> results = new List<IOrderItem>();

            if (min == null)
            {
                foreach (IOrderItem item in items)
                {
                    if (item.Price <= (decimal)max) results.Add(item);
                }
                return results;
            }

            if (max == null)
            {
                foreach (IOrderItem item in items)
                {
                    if (item.Price >= (decimal)min) results.Add(item);
                }
                return results;
            }

            foreach (IOrderItem item in items)
            {
                if (item.Price >= (decimal)min && item.Price <= (decimal)max) results.Add(item);
            }
            return results;
        }
        

    }


}
