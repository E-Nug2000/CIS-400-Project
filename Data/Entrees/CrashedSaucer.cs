/*
 * Author: Edward Gruver
 * File: CrashedSaucer.cs
 * Purpose: defines the Crashed Saucer entree
 */

using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Entrees
{
    /// <summary>
    /// A class that represents the Crashed Saucer entree
    /// </summary>
    public class CrashedSaucer : Entree, IOrderItem, INotifyPropertyChanged
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
        /// The name of the entree
        /// </summary>
        public override string Name => "Crashed Saucer";

        /// <summary>
        /// The description of the entree
        /// </summary>
        public override string Description => "A stack of thick-sliced french toast, served with whipped cream, butter and your choice of syrup.";

        /// <summary>
        /// The calories of the dish. If half stack then half calories
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (HalfStack) return 255u;
                else return 510u;
            }
        }
        
        /// <summary>
        /// The price of the entree, if half stack then half price
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (HalfStack) return (decimal)3.70;
                else return (decimal)5.80;
            }
        }

        private bool halfStack = false;
        /// <summary>
        /// Boolean to indicate whether or not the dish is a half stack
        /// </summary>
        public bool HalfStack
        {
            get
            {
                return halfStack;
            }
            set
            {
                if (halfStack != value)
                {
                    halfStack = value;
                    NotifyChangeProperty(this, "HalfStack");
                    NotifyChangeProperty(this, "Calories");
                    NotifyChangeProperty(this, "Price");
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
                if (HalfStack) instructions.Add("Half Stack");
                instructions.Add(SyrupFlavor.ToString() + " Syrup");
                return instructions;

            }
        }


    }
}
