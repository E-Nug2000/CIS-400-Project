/*
 * Author: Edward Gruver
 * File Name: Drink.cs
 * Purpose: represents the Liquified Vegetation drink (juice)
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Enums;
using System.ComponentModel;

namespace TheFlyingSaucer.Data.Drinks
{


    /// <summary>
    /// The Liquified Vegetation drink (juice)
    /// </summary>
    public class LiquifiedVegetation : Drink, IOrderItem, INotifyPropertyChanged
    {


        /// <summary>
        /// The name of the drink
        /// </summary>
        public override string Name
        {
            get
            {
                 
                return Size.ToString() + " Liquified Vegetation"; ;
            }
        }

        /// <summary>
        /// The description of the drink
        /// </summary>
        public override string Description => "Fresh juice extracted from the finest fruits and vegetables.";

        /// <summary>
        ///The flavor of the drink
        /// </summary>
        private JuiceFlavor juiceFlavor = JuiceFlavor.Orange;
        public JuiceFlavor JuiceFlavor
        {
            get
            {
                return juiceFlavor;
            }
            set
            {
                if (juiceFlavor != value)
                {
                    juiceFlavor = value;
                    NotifyChangeProperty(this, "JuiceFlavor");
                    NotifyChangeProperty(this, "SpecialInstructions");
                }
            }
        }

        /// <summary>
        /// The number of calories in the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (JuiceFlavor)
                {
                    case JuiceFlavor.Cranberry:
                        if (Size == Size.Small) return 117u;
                        if (Size == Size.Medium) return 234u;
                        else return 481u;
                    case JuiceFlavor.Grape:
                        if (Size == Size.Small) return 152u;
                        if (Size == Size.Medium) return 234u;
                        else return 481;
                    case JuiceFlavor.Apple:
                        if (Size == Size.Small) return 113u;
                        if (Size == Size.Medium) return 226u;
                        else return 339u;
                    case JuiceFlavor.Tomato:
                        if (Size == Size.Small) return 42u;
                        if (Size == Size.Medium) return 84u;
                        else return 126u;
                    default:
                        if (Size == Size.Small) return 111u;
                        if (Size == Size.Medium) return 222u;
                        else return 333u;
                }
            }

        }
        
        /// <summary>
        /// a list of special instructions for the drink
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                switch (JuiceFlavor)
                {
                    case JuiceFlavor.Cranberry:
                        instructions.Add("Cranberry Juice");
                        break;
                    case JuiceFlavor.Grape:
                        instructions.Add("Grape Juice");
                        break;
                    case JuiceFlavor.Apple:
                        instructions.Add("Apple Juice");
                        break;
                    case JuiceFlavor.Tomato:
                        instructions.Add("Tomato Juice");
                        break;
                    default:
                        instructions.Add("Orange Juice");
                        break;
                }
                return instructions;
            }
        }
        
    }
}
