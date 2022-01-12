/*
 * Author: Edward Gruver
 * File: TakenBacon.cs
 * Purpose: defines the Taken Bacon side
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// Class that represents the Taken Bacon side
    /// </summary>
    public class TakenBacon:Side,IOrderItem
    {
        /// <summary>
        /// Name of the side
        /// </summary>
        public override string Name => Size.ToString() + " Taken Bacon";

        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description => "Crispy thick-sliced strips of hickory-smoked bacon.";

        /// <summary>
        /// The number of calories in the side
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Small) return 43u;
                else if (Size == Size.Large) return 129u;
                else return 86u;
            }
        }

    }
}
