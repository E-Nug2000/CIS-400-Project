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
    /// <summary>
    /// Mock object to be used in testing
    /// </summary>
    public class TestOrderItem : IOrderItem, INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// the price of the item
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Calories of the item
        /// </summary>
        public uint Calories { get; set; }

        /// <summary>
        /// The special intructions
        /// </summary>
        public List<string> SpecialInstructions { get; set; }

        /// <summary>
        /// PropertyChanged event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

    }

    public class OrderTests
    {
        [Fact]
        public void CanAddToOrder()
        {
            Order ord = new Order();
            TestOrderItem mo = new TestOrderItem();
            ord.Add(mo);
            Assert.Contains(mo, ord);
        }

        [Fact]
        public void CanRemoveFromOrder()
        {
            Order ord = new Order();
            TestOrderItem mo = new TestOrderItem();
            ord.Add(mo);
            ord.Remove(mo);
            Assert.Empty(ord);
        }

        [Fact]
        public void ImplementsINotifycollectionChangedInterface()
        {
            Order ord = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(ord);
        }
        [Fact]
        public void ImplementsINotifyPropertyChangedInterface()
        {
            Order ord = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ord);
        }


        [Theory]
        [InlineData("Subtotal")]
        [InlineData("Tax")]
        [InlineData("Total")]
        [InlineData("Calories")]
        public void NotifiesPropertyChangedWhenItemAdded(string property)
        {
            Order ord = new Order();
            TestOrderItem mo = new TestOrderItem();
            Assert.PropertyChanged(ord, property, () => ord.Add(mo));
        }

        [Fact]
        public void NotifiesCollectionChangeWhenItemAdded()
        {
            Order ord = new Order();
            TestOrderItem mo = new TestOrderItem();
            NotifyCollectionChangedEventArgs args = null;
            ord.CollectionChanged += (sender, e) =>
            {
                args = e;
            };
            ord.Add(mo);
            Assert.NotNull(args);
            Assert.Equal(NotifyCollectionChangedAction.Add, args.Action);
            Assert.Equal(mo, args.NewItems[0]);
            Assert.Equal(1, args.NewItems.Count);
            Assert.Null(args.OldItems);
        }

    }
}
