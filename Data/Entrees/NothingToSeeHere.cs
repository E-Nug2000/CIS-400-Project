/*
 * Author: Edward Gruver
 * File: CrashedSaucer.cs
 * Purpose: defines the Nothing to See Here entree
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Entrees
{
    public class NothingToSeeHere:Entree, IOrderItem, INotifyPropertyChanged
    {

        /// <summary>
        /// The enum for eggstyles 
        /// </summary>
        private EggStyle eggStyle = EggStyle.Scrambled;
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
        /// The name of the entree
        /// </summary>
        public override string Name => "Nothing to See Here";

        /// <summary>
        /// The description of the entree
        /// </summary>
        public override string Description => "The breakfast classic of bacon, eggs, and Texas toast.";

        /// <summary>
        /// gets the calories of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (SubstituteSausage) return 543u;
                else return 512u;
            }
        }

        /// <summary>
        /// Gets the price of the entree
        /// </summary>
        public override decimal Price
        {
            get
            {
                return (decimal)3.50;
            }
        }

        private bool substituteSausage = false;
        /// Boolean to indicate whether or not the dish is substituted with sausage
        /// </summary>
        public bool SubstituteSausage
        {
            get
            {
                return substituteSausage;
            }
            set
            {
                substituteSausage = value;
                NotifyChangeProperty(this, "SubstituteSausage");
                NotifyChangeProperty(this, "SpecialInstructions");
                NotifyChangeProperty(this, "Calories");
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
                if (SubstituteSausage) instructions.Add("Substitute Sausage");
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
