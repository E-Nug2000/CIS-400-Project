/*
 * Author: Edward Gruver
 * File: YoureToast.cs
 * Purpose: defines the You're Toast side
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// Class that represents the You're Toast side
    /// </summary>
    public class YoureToast:Side,IOrderItem
    {
        /// <summary>
        /// Name of the side
        /// </summary>
        public override string Name => Size.ToString() + " You're Toast!";

        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description => "Thick, crusty slabs of Texas Toast.";

        /// <summary>
        /// The number of calories in the side
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Small) return 100u;
                else if (Size == Size.Large) return 300u;
                else return 200u;
            }
        }
    }
}
