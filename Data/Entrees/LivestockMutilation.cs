/* File: LivestockMutilation.cs
 * Author: Edward Gruver
 * Purpose: Defines the Livestock Mutilation entreee
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Entrees
{
    /// <summary>
    /// A class representing the Livestock Mutilation entree which is biscuits and gravy
    /// </summary>
    public class LivestockMutilation:Entree,IOrderItem, INotifyPropertyChanged
    {


        /// <summary>
        /// The name of the entree
        /// </summary>
        public override string Name => "Livestock Mutilation";

        /// <summary>
        /// The description of the entree
        /// </summary>
        public override string Description => "A hearty gravy saturated with sausage, poured over fluffy golden buttermilk biscuits.";

        /// <summary>
        /// gets the calories of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                return 332u;
            }
        }

        /// <summary>
        /// Gets the price of the entree
        /// </summary>
        public override decimal Price
        {
            get
            {
                return (decimal)6.10;
            }
        }

        private bool gravyOnTheSide = false;

        /// <summary>
        /// Gets or sets whether we want gravy on the side
        /// </summary>
        public bool GravyOnTheSide
        {
            get
            {
                return gravyOnTheSide;
            }
            set
            {
                if (gravyOnTheSide != value)
                {
                    gravyOnTheSide = value;
                    NotifyChangeProperty(this, "GravyOnTheSide");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        /// <summary>
        /// Gets the special instructions for the entree
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (GravyOnTheSide) instructions.Add("Gravy on the Side");
                return instructions;
            }
            
        }
    }
}
