/*
 * Author: Edward Gruver
 * File Name: FlyingSaucer.cs
 * Purpose: defines the Flying Saucer dish
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Entrees
{
    /// <summary>
    /// A class that represents the Flying Saucer Entree
    /// </summary>
    public class FlyingSaucer : Entree, IOrderItem, INotifyPropertyChanged
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
        /// the name of the dish
        /// </summary>
        public override string Name => "Flying Saucer";

        /// <summary>
        /// The description of the dish
        /// </summary>
        public override string Description => "Our namesake dish. A full stack of fluffy golden pancakes, served with whipped cream, butter and your choice of syrup.";

        /// <summary>
        /// The calories of the dish
        /// If the dish is a half stack the calories are 127, otherwise they are 254
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (HalfStack == true) return 127u;
                else return 254u;
            }
        }

        /// <summary>
        /// The price of the dish
        /// If the dish is a half stack the price is $3.25, otherwise its $5.50
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (HalfStack == true) return (decimal)3.25;
                else return (decimal)5.5;
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

