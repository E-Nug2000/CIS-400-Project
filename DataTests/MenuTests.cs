/*
 * Author: Edward Gruver
 * File name: OrderTests.cs
 * Purpose: Unit testing order class
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Entrees;
using TheFlyingSaucer.Data.Sides;
using Xunit;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections;

namespace TheFlyingSaucer.DataTests
{
    
    public class MenuTests
    {

       /* [Fact]
        public void CanFilterByName()
        {
           
            string terms = "Crashed Saucer";
            IEnumerable<IOrderItem> item =  Menu.Search(terms);
            foreach(IOrderItem menuItem in item)
            {
                if(menuItem.Name == "Crashed Saucer")
                {
                    Assert.True(menuItem.Name == "Crashed Saucer");
                }

            }
        }

        [Fact]
        public void CanFilterByDescriptionAndDescriptionIsCaseInsensitive()
        {
            string terms = "staCk Of ThIck-sliced";
            IEnumerable<IOrderItem> item = Menu.Search(terms);
            foreach (IOrderItem menuItem in item)
            {
                if (menuItem.Description.Contains("stack of thick-sliced"))
                {
                    Assert.Contains(menuItem.Description, 
                        "A stack of thick-sliced french toast, served with whipped cream, butter and your choice of syrup.");
                }

            }
        }

        [Fact]
        public void CanFilterByCategory()
        {
            List<string> categories = new List<string>();
            categories.Add("Entrees");

            IEnumerable<IOrderItem> item = Menu.FilterByCategory(categories);
            foreach(IOrderItem menuitem in item)
            {
                Assert.IsAssignableFrom<Entree>(menuitem);
            }
        }

        [Fact]
        public void CanFilterByCaloriesAndAcceptNull()
        {
            IEnumerable<IOrderItem> items = Menu.Search(null);
            IEnumerable<IOrderItem> items2 = Menu.FilterByCalories(items,0, 500);
            foreach(IOrderItem menuitem in items2)
            {
                Assert.True(menuitem.Calories >= 0 && menuitem.Calories <= 500);
            }

        }

        [Fact]
        public void CanFilterByPrice()
        {
            IEnumerable<IOrderItem> items = Menu.Search(null);
            IEnumerable<IOrderItem> items2 = Menu.FilterByPrice(items, 0, 8.50);
            foreach (IOrderItem menuitem in items2)
            {
                Assert.True(menuitem.Price >= 0 && menuitem.Price <= (decimal)8.50);
            }
        }

        [Fact]
        public void CanFilterBetween0AndNullCalories()
        {
            IEnumerable<IOrderItem> items = Menu.Search(null);
            IEnumerable<IOrderItem> items2 = Menu.FilterByCalories(items, 0, null);
            foreach (IOrderItem menuitem in items2)
            {
                Assert.True(menuitem.Calories >= 0);
            }
        }

        [Fact]
        public void CanFilterBetweenNullAnd500Calories()
        {
            IEnumerable<IOrderItem> items = Menu.Search(null);
            IEnumerable<IOrderItem> items2 = Menu.FilterByCalories(items, null, 500);
            foreach (IOrderItem menuitem in items2)
            {
                Assert.True(menuitem.Calories <= 500);
            }
        }


        [Fact]
        public void CanFilterBetweenNulland850Price()
        {
            IEnumerable<IOrderItem> items = Menu.Search(null);
            IEnumerable<IOrderItem> items2 = Menu.FilterByPrice(items, null, 8.50);
            foreach (IOrderItem menuitem in items2)
            {
                Assert.True(menuitem.Price <= (decimal)8.50);
            }
        }

        [Fact]
        public void CanFilterBetween1AndNullPrice()
        {
            IEnumerable<IOrderItem> items = Menu.Search(null);
            IEnumerable<IOrderItem> items2 = Menu.FilterByPrice(items, 1, null);
            foreach (IOrderItem menuitem in items2)
            {
                Assert.True(menuitem.Price >= 1);
            }
        }
       */
    }

    public class WebsiteTests
    {
        [Fact]
        public void SearchForCrashedSaucer()
        {
            
            string searchTerm = "Crashed Saucer";
             
            
        } 
    }

}
