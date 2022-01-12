/*
 * Author: Edward Gruver
 * File: CropCircleOats.cs
 * Purpose: defines the Crop Circle Oats side
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// Class representing the Crop Circle Oats side
    /// </summary>
    public class CropCircleOats:Side, IOrderItem,INotifyPropertyChanged
    {
        /// <summary>
        /// The syrup flvaor for the dish
        /// </summary>
        private SyrupFlavor syrupFlavor = SyrupFlavor.Maple;
        public SyrupFlavor SyrupFlavor
        {
            get
            {
                return syrupFlavor;
            }
            set
            {
                syrupFlavor = value;
                NotifyChangeProperty(this, "SyrupFlavor");
                NotifyChangeProperty(this, "SpecialInstructions");
            }
        }

        /// <summary>
        /// Name of the side
        /// </summary>
        public override string Name => Size.ToString() +  " Crop Circle Oats";


        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description => "A hearty oatmeal doused in butter and your choice of syrup.";

        /// <summary>
        /// The number of calories in the side
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Small) return 158u;
                else if (Size == Size.Large) return 484u;
                else return 316u;
            }
        }

        /// <summary>
        /// Whether or not the side will have butter
        /// </summary>
        private bool butter = true;
        public bool Butter
        {
            get
            {
                return butter;
            }
            set
            {
                butter = value;
                NotifyChangeProperty(this, "Butter");
                NotifyChangeProperty(this, "SpecialInstructions");
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
                if (!Butter) instructions.Add("Hold Butter");
                instructions.Add(SyrupFlavor.ToString() + " Syrup");
                return instructions;

            }
        }




    }
}
