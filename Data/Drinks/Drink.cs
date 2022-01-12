/*
 * Author: Edward Gruver
 * File Name: Drink.cs
 * Purpose: To provide the base class for drinks
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// base class for drinks
    /// </summary>
    public class Drink : IOrderItem, INotifyPropertyChanged
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
        /// The name of the drink
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// The description of the drink
        /// </summary>
        public virtual string Description { get; set; }


        /// <summary>
        /// The price of the drink
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                if (Size == Size.Small) return (decimal)1.00;
                else if (Size == Size.Large) return (decimal)2.00;
                else return (decimal)1.50;
            }

        }

        /// <summary>
        /// The calories of the entree
        /// </summary>
        public virtual uint Calories { get; }

        /// <summary>
        /// a list of special instructions for the drink
        /// </summary>
        public virtual List<string> SpecialInstructions { get; }

        /// <summary>
        /// The size of the drink
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


        


    }
}
