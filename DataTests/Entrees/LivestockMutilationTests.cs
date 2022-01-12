/*
 * Author: Nathan Bean
 * File name: LivestockMutilationTests.cs
 * Purpose: Unit testing the CrashedSaucer class.
 */
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TheFlyingSaucer.Data.Entrees;
using TheFlyingSaucer.Data.Enums;

namespace TheFlyingSaucer.DataTests.Entrees
{
    /// <summary>
    /// Tests for the LivestockMutilation entree class
    /// </summary>
    public class LivestockMutilationTests
    {
        [Fact]
        public void NameShouldBeCorrect()
        {
            var lm = new LivestockMutilation();
            Assert.Equal("Livestock Mutilation", lm.Name);
        }

        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            var lm = new LivestockMutilation();
            string description = "A hearty gravy saturated with sausage, poured over fluffy golden buttermilk biscuits.";
            Assert.Equal(description, lm.Description);
        }

        [Fact]
        public void ShouldHaveCorrectCalories()
        {
            var lm = new LivestockMutilation();
            Assert.Equal(332u, lm.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectPrice()
        {
            var lm = new LivestockMutilation();
            Assert.Equal(6.10m, lm.Price);
        }

        [Fact]
        public void ShouldBeAbleToSetPotatoes()
        {
            var lm = new LivestockMutilation();
            lm.GravyOnTheSide = true;
            Assert.True(lm.GravyOnTheSide);
            lm.GravyOnTheSide = false;
            Assert.False(lm.GravyOnTheSide);
        }

        [Theory]
        [InlineData(false, new string[] { })]
        [InlineData(true, new string[] { "Gravy on the Side" })]
        public void ShouldProvideCurrentSpecialInstructions(bool gravyOnTheSide, string[] instructions)
        {
            var lm = new LivestockMutilation()
            {
                GravyOnTheSide = gravyOnTheSide
            };
            foreach (var expected in instructions)
            {
                Assert.Contains(expected, lm.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, lm.SpecialInstructions.Count);
        }

        [Theory]
        [InlineData("GravyOnTheSide")]
        [InlineData("SpecialInstructions")]
        public void ChangeGravyOnTheSide(string property)
        {
            LivestockMutilation entree = new LivestockMutilation();
            Assert.PropertyChanged(entree, property, () => { entree.GravyOnTheSide = true; });
        }
    }
}
