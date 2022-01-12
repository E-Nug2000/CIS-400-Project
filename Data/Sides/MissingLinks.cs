/*
 * Author: Edward Gruver
 * File: MissingLinks.cs
 * Purpose: defines the Missing Links side
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Sides
{
    /// <summary>
    /// Class that represents the Missing Links side
    /// </summary>
    public class MissingLinks:Side,IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Name of the side
        /// </summary>
        public override string Name => Size.ToString() + " Missing Links";

        /// <summary>
        /// The description of the side
        /// </summary>
        public override string Description => "Rich sage sausage links cooked to perfection.";

        /// <summary>
        /// The number of calories in the side
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Small) return 391u;
                else if (Size == Size.Large) return 1173u;
                else return 782u;
            }
        }

    }
}
