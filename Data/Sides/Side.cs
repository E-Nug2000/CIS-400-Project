/*
 * Author: Edward Gruver
 * File Name: Entree.cs
 * Purpose: To provide the base class for entrees
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// The base class for the side
    /// </summary>
    public abstract class Side : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// An event fired when a property of this object changes
        /// </summary
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method that will notify that the property has changed
        /// </summary>
        /// <param name="item"></param>
        /// <param name="propertyName"></param>
        public void NotifyChangeProperty(object item, string propertyName)
        {
            PropertyChanged?.Invoke(item, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The size of the side
        /// </summary>
        private Size size = Size.Medium;
        public virtual Size Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                NotifyChangeProperty(this, "Size");
                NotifyChangeProperty(this, "Name");
                NotifyChangeProperty(this, "Calories");
                NotifyChangeProperty(this, "Price");
            }
        }

        /// <summary>
        /// The name of the side
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// The description of the side
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// The price of the side
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                if (Size == Size.Small) return (decimal)1.50;
                else if (Size == Size.Large) return (decimal)2.50;
                else return (decimal)2.00;
            }
        }

        /// <summary>
        /// The calories of the side
        /// </summary>
        public virtual uint Calories { get; set; }

        /// <summary>
        /// a list of special instructions for the side
        /// </summary>
        public virtual List<string> SpecialInstructions { get; set; }

        
    }
}
