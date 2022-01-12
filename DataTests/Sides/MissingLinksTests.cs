/*
 * Author: Edward Gruver
 * File name: MissingLinksTests.cs
 * Purpose: Unit testing the Missing Links class
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
    public class MissingLinksTests
    {
        [Fact]
        public void NameIsCorrectForSize()
        {
            var ml = new MissingLinks();
            Assert.Equal(ml.Size.ToString() + " Missing Links", ml.Name);
        }

        [Fact]
        public void DescriptionIsCorrect()
        {
            var ml = new MissingLinks();
            string description = "Rich sage sausage links cooked to perfection.";
            Assert.Equal(description, ml.Description);
        }

        [Theory]
        [InlineData(Size.Small, 391)]
        [InlineData(Size.Medium, 782)]
        [InlineData(Size.Large, 1173)]
        public void CaloriesAreCorrectForSize(Size size, uint calories)
        {
            var ml = new MissingLinks()
            {
                Size = size

            };
            Assert.Equal(calories, ml.Calories);
        }

        [Theory]
        [InlineData(Size.Small, 1.50)]
        [InlineData(Size.Medium, 2.00)]
        [InlineData(Size.Large, 2.50)]
        public void PriceIsCorrectForSize(Size size, decimal price)
        {
            var tb = new MissingLinks()
            {
                Size = size

            };
            Assert.Equal(price, tb.Price);
        }


        [Fact]

        public void SpecialInstructionsShouldBeEmpty()
        {
            var tb = new TakenBacon();
            Assert.True(tb.SpecialInstructions == null);

        }
    }
}