/*
 * Author: Edward Gruver
 * File name: CropCircleOatsTests.cs
 * Purpose: Unit testing the CropCircleOats class
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
    /// Unit tests for the GlowingHaystack class
    /// </summary>
    public class GlowingHaystackTests
    {
        [Fact]
        public void NameIsCorrectForSize()
        {
            var gh = new GlowingHaystack();
            Assert.Equal(gh.Size.ToString() + " Glowing Haystack", gh.Name);
        }

        [Fact]
        public void DescriptionIsCorrect()
        {
            var gh = new GlowingHaystack();
            string description = "A dense pile of crisp hash browns, smothered in roasted green pepper sauce.";
            Assert.Equal(description, gh.Description);
        }

        [Theory]
        [InlineData(Size.Small, 470)]
        [InlineData(Size.Medium, 610)]
        [InlineData(Size.Large, 785)]
        public void CaloriesAreCorrectForSize(Size size, uint calories)
        {
            var gh = new GlowingHaystack()
            {
                Size = size

            };
            Assert.Equal(calories, gh.Calories);
        }

        [Theory]
        [InlineData(Size.Small, 1.50)]
        [InlineData(Size.Medium, 2.00)]
        [InlineData(Size.Large, 2.50)]
        public void PriceIsCorrectForSize(Size size, decimal price)
        {
            var gh = new GlowingHaystack();
            {
                gh.Size = size;

            };
            Assert.Equal(price, gh.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetSauced(bool sauced)
        {
            var gh = new GlowingHaystack();
            gh.Sauced = sauced;
            Assert.Equal(sauced, gh.Sauced);
        }

        [Theory]
        [InlineData(false,new String[] { "Hold Sauce" })]
        [InlineData(true, new String[] { })]
        public void ShouldProvideCurrentSpecialInstructions(bool sauced, string[] instructions)
        {
            var gh = new GlowingHaystack()
            {
                Sauced = sauced
                
            };
            foreach (string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, gh.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count);
        }
    }
}