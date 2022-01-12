/*
 * Author: Edward Gruver
 * File Name: SaucerFuel.cs
 * Purpose: represents the Saucer Fuel drink (coffee)
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Drinks
{
    /// <summary>
    /// represents the Saucer Fuel drink (coffee)
    /// </summary>
    public class SaucerFuel:Drink,IOrderItem, INotifyPropertyChanged
    {

        /// <summary>
        /// Whether or not the coffee is decaf
        /// </summary>
        private bool decaf = false;
        public bool Decaf
        {
            get
            {
                return decaf;
            }
            set
            {
                if (decaf != value)
                {
                    decaf = value;
                    NotifyChangeProperty(this, "Decaf");
                    NotifyChangeProperty(this, "SpecialInstructions");
                    NotifyChangeProperty(this, "Name");
                }
            }
        }

        /// <summary>
        /// The name of the drink
        /// </summary>
        public override string Name
        {
            get
            {
                if (Decaf) return Size.ToString() + " Decaf Saucer Fuel";
                else return Size.ToString() + " Saucer Fuel";
            }
        }

        /// <summary>
        /// The description of the drink
        /// </summary>
        public override string Description => "Beamed directly from the best coffee plantations of South America, our rich brew is bound to put a bounce in your spacewalk.";

        /// <summary>
        /// The price of the drink
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Size == Size.Small) return (decimal)1.00;
                else if (Size == Size.Large) return (decimal)1.40;
                else return (decimal)1.20;
            }
        }

        /// <summary>
        /// The number of calories in the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Small) return 1u;
                else if (Size == Size.Large) return 3u;
                else return 2u;
            }
        }

        /// <summary>
        /// Whether or not to add cream
        /// </summary>
        private bool cream = false;
        public bool RoomForCream
        {
            get
            {
                return cream;
            }
            set
            {
                if (cream != value)
                {
                    cream = value;
                    NotifyChangeProperty(this, "RoomForCream");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        /// <summary>
        /// a list of special instructions for the drink
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (RoomForCream) instructions.Add("Room for Cream");
                if (Decaf) instructions.Add("Decaf");
                return instructions;
            }
        }

    }
}
