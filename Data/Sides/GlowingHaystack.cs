/*
 * Author: Edward Gruver
 * File: GlowingHaystack.cs
 * Purpose: defines the Glowing Haystack side
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// Class representing the Glowing Haystack side
    /// </summary>
    public class GlowingHaystack:Side,IOrderItem, INotifyPropertyChanged
    {

        /// <summary>
        /// Name of the side
        /// </summary>
        public override string Name => Size.ToString() + " Glowing Haystack";


        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description => "A dense pile of crisp hash browns, smothered in roasted green pepper sauce.";

        /// <summary>
        /// The number of calories in the side
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Small) return 470u;
                else if (Size == Size.Large) return 785u;
                else return 610u;
            }
        }

        /// <summary>
        /// Whether or not the side will have butter
        /// </summary>
        private bool sauced = true;
        public bool Sauced
        {
            get
            {
                return sauced;
            }
            set
            {
                if (sauced != value)
                {
                    sauced = value;
                    NotifyChangeProperty(this, "Sauced");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        /// <summary>
        /// The special instructions for the dish, kept as a string list. 
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Sauced) instructions.Add("Hold Sauce");
                return instructions;

            }
        }
    }
}
