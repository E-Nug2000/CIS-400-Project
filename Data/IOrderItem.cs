/*
 * Author: Edward Gruver
 * File Name: IOrderItem.cs
 * Purpose: Interface for all menu items
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using TheFlyingSaucer.Data.Enums;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Interface for all menu items
    /// </summary>
    public interface IOrderItem : INotifyPropertyChanged
    {
        string Name { get; }

        string Description { get; }

        /// <summary>
        /// the price of the item
        /// </summary>
         decimal Price { get; }

        /// <summary>
        /// Calories of the item
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// The special intructions
        /// </summary>
        List<string> SpecialInstructions { get; }


    }
}
