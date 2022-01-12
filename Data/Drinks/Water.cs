/*
 * Author: Edward Gruver
 * File Name: Water.cs
 * Purpose: represents a glass of water
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Drinks
{
    /// <summary>
    /// Class that represents a glass of water
    /// </summary>
    public class Water:Drink,IOrderItem, INotifyPropertyChanged
    {


        /// <summary>
        /// The name of the drink
        /// </summary>
        public override string Name => Size.ToString() + " Water";

        /// <summary>
        /// The description of the drink
        /// </summary>
        public override string Description => "Watch out if you come from a planet where pure H2O is deadly, because that’s all this is! ";

        /// <summary>
        /// The price of the drink
        /// </summary>
        public override decimal Price => (decimal)0.0;

        /// <summary>
        /// Whether or not to add ice
        /// </summary>
        private bool ice = true;
        public bool Ice
        {
            get
            {
                return ice;
            }
            set
            {

                ice = value;
                NotifyChangeProperty(this, "Ice");
                NotifyChangeProperty(this, "SpecialInstructions");

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
                if (!Ice) instructions.Add("No Ice.");
                return instructions;
            }
        }
    }
}
