/*
 * Author: Edward Gruver
 * File: SpaceScramble.cs
 * Purpose: defines the Space Scramble entree
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;


namespace TheFlyingSaucer.Data.Entrees
{


    public class SpaceScramble:Entree,IOrderItem, INotifyPropertyChanged
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
        public override string Name => "Space Scramble";

        /// <summary>
        /// The description of the entree
        /// </summary>
        public override string Description => "A hearty skillet-fried scramble of potatoes, sausage, peppers, jack cheddar cheese, sour cream, and topped with your choice of egg.";

        /// <summary>
        /// gets the calories of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 380u;
            }
        }

        /// <summary>
        /// Gets the price of the entree
        /// </summary>
        public override decimal Price
        {
            get
            {
                return (decimal)5.20;
            }
        }

        private bool potatoes = true;
        /// <summary>
        /// An ingredient that can be added to the entree
        /// Boil 'em, mash 'em, stick 'em in a stew
        /// </summary>
        public bool Potatoes 
        {
            get
            {
                return potatoes;
            }
            set
            {
                if (potatoes != value)
                {
                    potatoes = value;
                    NotifyChangeProperty(this, "Potatoes");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        private bool sausage = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool Sausage
        {
            get
            {
                return sausage;
            }
            set
            {
                if (sausage != value)
                {
                    sausage = value;
                    NotifyChangeProperty(this, "Sausage");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        private bool peppers = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool Peppers
        {
            get
            {
                return peppers;
            }
            set
            {
                if (peppers != value)
                {
                    peppers = value;
                    NotifyChangeProperty(this, "Peppers");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        private bool cheese = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool Cheese
        {
            get
            {
                return cheese;
            }
            set
            {
                if (cheese != value)
                {
                    cheese = value;
                    NotifyChangeProperty(this, "Cheese");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        private bool egg = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool Egg
        {
            get
            {
                return egg;
            }
            set
            {
                if (egg != value)
                {
                    egg = value;
                    NotifyChangeProperty(this, "Egg");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        private bool sourCream = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool SourCream
        {
            get
            {
                return sourCream;
            }
            set
            {
                if (sourCream != value)
                {
                    sourCream = value;
                    NotifyChangeProperty(this, "SourCream");
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
                if (SourCream == false) instructions.Add("Hold Sour Cream");
                if (Egg == false) instructions.Add("Hold Egg");
                if (Cheese == false) instructions.Add("Hold Cheese");
                if (Peppers == false) instructions.Add("Hold Peppers");
                if (Sausage == false) instructions.Add("Hold Sausage");
                if (Potatoes == false) instructions.Add("Hold Potatoes");
                if (Egg)
                {
                    if (EggStyle == EggStyle.Scrambled) instructions.Add("Eggs Scrambled");
                    if (EggStyle == EggStyle.Poached) instructions.Add("Eggs Poached");
                    if (EggStyle == EggStyle.HardBoiled) instructions.Add("Eggs Hard Boiled");
                    if (EggStyle == EggStyle.SunnySideUp) instructions.Add("Eggs Sunny Side Up");
                    if (EggStyle == EggStyle.OverEasy) instructions.Add("Eggs Over Easy");
                    if (EggStyle == EggStyle.OverMedium) instructions.Add("Eggs Over Medium");
                    if (EggStyle == EggStyle.OverWell) instructions.Add("Eggs Over Well");
                }
                return instructions;

            }
        }
    }
}
