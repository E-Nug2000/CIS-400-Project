/*
 * Author: Edward Gruver
 * File Name: Entree.cs
 * Purpose: To provide the base class for entrees
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// the base class for the Entree
    /// </summary>
    public abstract class Entree : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// An event fired when a property of this object changes
        /// </summary
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method that will notify that the property has changed
        /// </summary>
        /// <param name="item">The object with the property that is being modified</param>
        /// <param name="propertyName">the name of the property being modified</param>
        public void NotifyChangeProperty(object item, string propertyName)
        {
            PropertyChanged?.Invoke(item, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The name of the entree
        /// </summary>
        public virtual string Name { get; }

        /// <summary>
        /// The description of the entree
        /// </summary>
        public virtual string Description { get; }

        /// <summary>
        /// The price of the entree
        /// </summary>
        public virtual decimal Price { get; }

        /// <summary>
        /// The calories of the entree
        /// </summary>
        public virtual uint Calories { get; }

        /// <summary>
        /// a list of special instructions for the entree
        /// </summary>
        public virtual List<string> SpecialInstructions { get; }

    }
}
