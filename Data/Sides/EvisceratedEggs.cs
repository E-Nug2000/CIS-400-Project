/*
 * Author: Edward Gruver
 * File: EvisceratedEggs.cs
 * Purpose: defines the Eviscerated Eggs side
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// Class representing the Eviscerated Eggs side
    /// </summary>
    public class EvisceratedEggs:Side,IOrderItem, INotifyPropertyChanged
    {

        /// <summary>
        /// The egg style of the dish
        /// </summary>
        private EggStyle eggStyle = EggStyle.OverEasy;
        public EggStyle EggStyle
        {
            get
            {
                return eggStyle;
            }
            set
            {
                if (eggStyle != value)
                {
                    eggStyle = value;
                    NotifyChangeProperty(this, "EggStyle");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        /// <summary>
        /// Name of the side
        /// </summary>
        public override string Name => Size.ToString() + " Eviscerated Eggs";

        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description => "Farm-fresh eggs, served as you like!";

        /// <summary>
        /// The number of calories in the side
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Small) return 78u;
                else if (Size == Size.Large) return 234u;
                else return 156u;
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
                if (EggStyle == EggStyle.Scrambled) instructions.Add("Eggs Scrambled");
                if (EggStyle == EggStyle.Poached) instructions.Add("Eggs Poached");
                if (EggStyle == EggStyle.HardBoiled) instructions.Add("Eggs Hard Boiled");
                if (EggStyle == EggStyle.SunnySideUp) instructions.Add("Eggs Sunny Side Up");
                if (EggStyle == EggStyle.OverEasy) instructions.Add("Eggs Over Easy");
                if (EggStyle == EggStyle.OverMedium) instructions.Add("Eggs Over Medium");
                if (EggStyle == EggStyle.OverWell) instructions.Add("Eggs Over Well");
                return instructions;

            }
        }
    }
}
