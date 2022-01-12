/*
 * Author: Edward Gruver
 * File: TheOuterOmelette.cs
 * Purpose: defines the Outer Omelette entree
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Entrees
{
    public class OuterOmelette:Entree,IOrderItem, INotifyPropertyChanged
    {

        /// <summary>
        /// The name of the entree
        /// </summary>
        public override string Name => "Outer Omelette";

        /// <summary>
        /// The description of the entree
        /// </summary>
        public override string Description => "A loaded omelette stuffed with all the favorites.";

        /// <summary>
        /// gets the calories of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 510;
            }
        }

        /// <summary>
        /// Gets the price of the entree
        /// </summary>
        public override decimal Price
        {
            get
            {
                return (decimal)5.80;
            }
        }

        private bool tomatoes = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool Tomatoes
        {
            get
            {
                return tomatoes;
            }
            set
            {
                if (tomatoes != value)
                {
                    tomatoes = value;
                    NotifyChangeProperty(this, "Tomatoes");
                    NotifyChangeProperty(this, "SpecialInstructions");

                }
            }
        }

        private bool mushrooms = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool Mushrooms
        {
            get
            {
                return mushrooms;
            }
            set
            {
                if (mushrooms != value)
                {
                    mushrooms = value;
                    NotifyChangeProperty(this, "SpecialInstructions");
                    NotifyChangeProperty(this, "Mushrooms");
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

        private bool spinach = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool Spinach
        {
            get
            {
                return spinach;
            }
            set
            {
                if (spinach != value)
                {
                    spinach= value;
                    NotifyChangeProperty(this, "Spinach");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        private bool onions = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool Onions
        {
            get
            {
                return onions;
            }
            set
            {
                if (onions != value)
                {
                    onions = value;
                    NotifyChangeProperty(this, "Onions");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        private bool ham = true;
        /// <summary>
        /// An ingredient that can be removed/added to the entree
        /// </summary>
        public bool Ham
        {
            get
            {
                return ham;
            }
            set
            {
                if (ham != value)
                {
                    ham = value;
                    NotifyChangeProperty(this, "Ham");
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
                if (Cheese == false) instructions.Add("Hold Cheese");
                if (Peppers == false) instructions.Add("Hold Peppers");
                if (Ham == false) instructions.Add("Hold Ham");
                if (Onions == false) instructions.Add("Hold Onions");
                if (Mushrooms == false) instructions.Add("Hold Mushrooms");
                if (Spinach == false) instructions.Add("Hold Spinach");
                if (Tomatoes == false) instructions.Add("Hold Tomatoes");
                return instructions;

            }
        }
    }
}
