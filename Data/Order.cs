/*
 * Author: Edward Gruver
 * File: Order.cs
 * Purpose: Defines the order 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections;
using System.Diagnostics.Tracing;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// The class that represents and order
    /// </summary>
    public class Order: ICollection<IOrderItem>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        /// <summary>
        /// Collection of items in the order
        /// </summary>
        private ObservableCollection<IOrderItem> Collection = new ObservableCollection<IOrderItem>();

        /// <summary>
        /// PropertyChanged event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// CollectionChanged event handler
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;


        /// <summary>
        /// Constructor for the Order class
        /// </summary>
        public Order()
        {
            Number = nextOrderNumber;
            nextOrderNumber++;
            
        }


        /// <summary>
        /// Method to add to an order
        /// </summary>
        /// <param name="item">the item that will be added to the order</param>
        public void Add(IOrderItem item)
        {
            Collection.Add(item);
            //base.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            NotifyChangeProperty(this, "Subtotal");
            NotifyChangeProperty(this, "Tax");
            NotifyChangeProperty(this, "Total");
            NotifyChangeProperty(this, "Calories");
            item.PropertyChanged += OnChange;
            
        }

        /// <summary>
        /// Method to remove from an order
        /// </summary>
        /// <param name="item">the item that is to be removed from the order</param>
        public bool Remove(IOrderItem item)
        {
            
            int index = Collection.IndexOf(item);
            bool added = false;
            Collection.Remove(item);
            //base.Remove(item);
            if (Collection.Contains(item))
            {
                added = true;
            }
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,item,index));
            NotifyChangeProperty(this, "Subtotal");
            NotifyChangeProperty(this, "Tax");
            NotifyChangeProperty(this, "Total");
            NotifyChangeProperty(this, "Calories");
            item.PropertyChanged -= OnChange;
            return added;
            
        }


        /// <summary>
        /// Method that indicates what happens when the price or calories change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnChange(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Price")
            {
                NotifyChangeProperty(this, "Subtotal");
                NotifyChangeProperty(this, "Tax");
                NotifyChangeProperty(this, "Total");
            }
            else if (e.PropertyName == "Calories")
            {
                NotifyChangeProperty(this, "Calories");
            }

        }

        /// <summary>
        /// Sales tax rate property
        /// </summary>
        private double salesTaxRate = 0.12;
        public double SalesTaxRate
        {
            get
            {
                return salesTaxRate;
            }
            set
            {
                salesTaxRate = value;
            }
        }

        /// <summary>
        /// Price of all items in the order
        /// </summary>
        public decimal Subtotal
        {
            get {
                decimal subTotal = (decimal)0.00;
                foreach(IOrderItem item in this)
                {
                    subTotal += item.Price;
                }
                return subTotal; }
        }

        /// <summary>
        /// Tax added, or the Subtotal multiplied by SalesTaxRate
        /// </summary>
        public decimal Tax
        {
            get { return Subtotal * (decimal)SalesTaxRate; }
        }

        /// <summary>
        /// Sum of Subtotal and Tax
        /// </summary>
        public decimal Total
        {
            get { return this.Subtotal + this.Tax; }
        }

        /// <summary>
        /// Sum of all the calories in an order
        /// </summary>
        public uint Calories
        {
            get { return 0u; }
        }

        /// <summary>
        /// Number that identifies the order
        /// </summary>
        private static int nextOrderNumber = 1;
        public int Number
        {
            get;
        }

        /// <summary>
        /// the time the order was placed
        /// </summary>
        private DateTime placedAt = DateTime.Now;
        public DateTime PlacedAt
        {
            get { return placedAt; }
        }

        public int Count => ((ICollection<IOrderItem>)Collection).Count;

        public bool IsReadOnly => ((ICollection<IOrderItem>)Collection).IsReadOnly;

        

        /// <summary>
        /// Method that will notify that the property has changed
        /// </summary>
        /// <param name="item"></param>
        /// <param name="propertyName"></param>
        public void NotifyChangeProperty(object item, string propertyName)
        {
            PropertyChanged?.Invoke(item, new PropertyChangedEventArgs(propertyName));
            //OnPropertyChanged(new PropertyChangedEventArgs(propertyName));         
        }

        public void Clear()
        {
            ((ICollection<IOrderItem>)Collection).Clear();
        }

        public bool Contains(IOrderItem item)
        {
            return ((ICollection<IOrderItem>)Collection).Contains(item);
        }

        public void CopyTo(IOrderItem[] array, int arrayIndex)
        {
            ((ICollection<IOrderItem>)Collection).CopyTo(array, arrayIndex);
        }

        bool ICollection<IOrderItem>.Remove(IOrderItem item)
        {
            return ((ICollection<IOrderItem>)Collection).Remove(item);
        }

        public IEnumerator<IOrderItem> GetEnumerator()
        {
            return ((IEnumerable<IOrderItem>)Collection).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Collection).GetEnumerator();
        }
    }
}
