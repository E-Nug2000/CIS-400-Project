/*
 * Author: Edward Gruver
 * File name: SaucerFuelTests.cs
 * Purpose: Unit testing the SaucerFuel class
 */
using System;
using System.Collections.Generic;
using System.Text;
using TheFlyingSaucer.Data.Drinks;
using TheFlyingSaucer.Data.Enums;
using TheFlyingSaucer.Data;
using Xunit;

namespace TheFlyingSaucer.DataTests.Drinks
{
    /// <summary>
    /// Unit tests for the SaucerFuel class
    /// </summary>
    public class SaucerFuelTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameIsCorrectForSizeandDecaf(bool decaf)
        {
            var sf = new SaucerFuel();
            sf.Decaf = decaf;
            if (decaf)
            {
                Assert.Equal(sf.Size.ToString() + " Decaf Saucer Fuel", sf.Name);
            }
            else Assert.Equal(sf.Size.ToString() + " Saucer Fuel", sf.Name);

        }

        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            var cs = new SaucerFuel();
            string description = "Beamed directly from the best coffee plantations of South America, our rich brew is bound to put a bounce in your spacewalk.";
            Assert.Equal(description, cs.Description);
        }

        [Theory]
        [InlineData(Size.Small, 1u)]
        [InlineData(Size.Medium, 2u)]
        [InlineData(Size.Large, 3u)]
        public void CaloriesAreCorrectForSize(Size size, uint calories)
        {
            var cco = new SaucerFuel()
            {
                Size = size,

            };
            Assert.Equal(calories, cco.Calories);
        }

        [Theory]
        [InlineData(true, true, new String[] { "Room for Cream", "Decaf" })]
        [InlineData(true, false, new String[] {"Room for Cream" })]
        [InlineData(false, true, new String[] {  "Decaf" })]
        [InlineData(false, false, new String[] {  })]
        public void ShouldProvideCurrentSpecialInstructions(bool cream, bool decaf, string[] instructions)
        {
            var gh = new SaucerFuel()
            {
                RoomForCream = cream,
                Decaf = decaf

            };
            foreach (string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, gh.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count);
        }

        [Theory]
        [InlineData(Size.Small, 1.00)]
        [InlineData(Size.Medium, 1.20)]
        [InlineData(Size.Large, 1.40)]
        public void PriceIsCorrectForSize(Size size, decimal price)
        {
            var gh = new SaucerFuel();
            {
                gh.Size = size;

            };
            Assert.Equal(price, gh.Price);
        }


        [Theory]
        [InlineData("Size")]
        [InlineData("Name")]
        [InlineData("Calories")]
        [InlineData("Price")]
        public void CanChangeSize(string property)
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.PropertyChanged(drink, property, () => { drink.Size = Size.Medium; });
            Assert.PropertyChanged(drink, property, () => { drink.Size = Size.Large; });
            Assert.PropertyChanged(drink, property, () => { drink.Size = Size.Small; });
        }

        [Theory]
        [InlineData("Decaf")]
        [InlineData("SpecialInstructions")]
        public void CanChangeDecaf(string property)
        {
            SaucerFuel drink = new SaucerFuel();
            Assert.PropertyChanged(drink, property, () => { drink.Decaf = true; });
        }

        [Theory]
        [InlineData("RoomForCream")]
        [InlineData("SpecialInstructions")]
        public void CanChangeCream(string property)
        {
            SaucerFuel drink = new SaucerFuel();
            Assert.PropertyChanged(drink, property, () => { drink.RoomForCream = true; });
        }

    }
}
