/*
 * Author: Edward Gruver
 * File name: EvisceratedEggsTests.cs
 * Purpose: Unit testing the Eviscerated Eggs class
 */
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TheFlyingSaucer.Data.Sides;
using TheFlyingSaucer.Data.Enums;

namespace TheFlyingSaucer.DataTests.Sides
{
    /// <summary>
    /// Unit tests for the MissingLinks class
    /// </summary>
    public class EvisceratedEggsTests
    {
        [Fact]
        public void NameIsCorrectForSize()
        {
            var ee = new EvisceratedEggs();
            Assert.Equal(ee.Size.ToString() + " Eviscerated Eggs", ee.Name);
        }

        [Fact]
        public void DescriptionIsCorrect()
        {
            var ee = new EvisceratedEggs();
            string description = "Farm-fresh eggs, served as you like!";
            Assert.Equal(description, ee.Description);
        }

        [Theory]
        [InlineData(Size.Small, 78)]
        [InlineData(Size.Medium, 156)]
        [InlineData(Size.Large, 234)]
        public void CaloriesAreCorrectForSize(Size size, uint calories)
        {
            var ee = new EvisceratedEggs()
            {
                Size = size

            };
            Assert.Equal(calories, ee.Calories);
        }

        [Theory]
        [InlineData(Size.Small, 1.50)]
        [InlineData(Size.Medium, 2.00)]
        [InlineData(Size.Large, 2.50)]
        public void PriceIsCorrectForSize(Size size, decimal price)
        {
            var tb = new EvisceratedEggs()
            {
                Size = size

            };
            Assert.Equal(price, tb.Price);
        }

        [Theory]
        [InlineData(EggStyle.HardBoiled)]
        [InlineData(EggStyle.OverEasy)]
        [InlineData(EggStyle.OverMedium)]
        [InlineData(EggStyle.OverWell)]
        [InlineData(EggStyle.Poached)]
        [InlineData(EggStyle.Scrambled)]
        [InlineData(EggStyle.SunnySideUp)]
        public void ShouldBeAbleToSetEggStyle(EggStyle eggStyle)
        {
            var ee = new EvisceratedEggs();
            ee.EggStyle = eggStyle;
            Assert.Equal(eggStyle, ee.EggStyle);
        }

        [Theory]
        [InlineData(EggStyle.HardBoiled, new String[] { "Eggs Hard Boiled" })]
        [InlineData(EggStyle.OverEasy, new String[] { "Eggs Over Easy" })]
        [InlineData(EggStyle.OverMedium, new String[] { "Eggs Over Medium" })]
        [InlineData(EggStyle.OverWell, new String[] { "Eggs Over Well" })]
        [InlineData(EggStyle.Poached, new String[] { "Eggs Poached" })]
        [InlineData(EggStyle.Scrambled, new String[] { "Eggs Scrambled" })]
        [InlineData(EggStyle.SunnySideUp, new String[] { "Eggs Sunny Side Up" })]
        public void ShouldProvideCurrentSpecialInstructions(EggStyle eggStyle, string[] instructions)
        {
            var ee = new EvisceratedEggs()
            {
                EggStyle = eggStyle
            };
            foreach (string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, ee.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, ee.SpecialInstructions.Count);
        }
    }
}