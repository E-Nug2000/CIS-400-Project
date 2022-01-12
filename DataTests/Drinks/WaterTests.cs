/*
 * Author: Edward Gruver
 * File name: WaterTests.cs
 * Purpose: Unit testing the Water class
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
    /// Unit tests for the Water class
    /// </summary>
    public class WaterTests
    {
        [Fact]
        public void NameIsCorrectForSize()
        {
            var cco = new Water();
            Assert.Equal(cco.Size.ToString() + " Water", cco.Name);
        }

        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            var cs = new Water();
            string description = "Watch out if you come from a planet where pure H2O is deadly, because that’s all this is! ";
            Assert.Equal(description, cs.Description);
        }

        [Theory]
        [InlineData(true,new String[] {  })]
        [InlineData(false, new String[] { "No Ice." })]
        public void ShouldProvideCurrentSpecialInstructions(bool ice, string[] instructions)
        {
            var gh = new Water()
            {
                Ice = ice,

            };
            foreach (string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, gh.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count);
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
        [InlineData("Ice")]
        [InlineData("SpecialInstructions")]
        public void CanChangeIce (string property)
        {
            Water drink = new Water();
            Assert.PropertyChanged(drink, property, () => { drink.Ice = true; });
        }



    }
}
