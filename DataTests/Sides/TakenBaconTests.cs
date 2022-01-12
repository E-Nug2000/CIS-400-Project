/*
 * Author: Edward Gruver
 * File name: TakenBaconTests.cs
 * Purpose: Unit testing the TakenBacon class
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
    /// Unit tests for the TakenBacon class
    /// </summary>
    public class TakenBaconTests
    {
        [Fact]
        public void NameIsCorrectForSize()
        {
            var tb = new TakenBacon();
            Assert.Equal(tb.Size.ToString() + " Taken Bacon", tb.Name);
        }

        [Fact]
        public void DescriptionIsCorrect()
        {
            var tb = new TakenBacon();
            string description = "Crispy thick-sliced strips of hickory-smoked bacon.";
            Assert.Equal(description, tb.Description);
        }

        [Theory]
        [InlineData(Size.Small, 43)]
        [InlineData(Size.Medium, 86)]
        [InlineData(Size.Large, 129)]
        public void CaloriesAreCorrectForSize(Size size, uint calories)
        {
            var tb = new TakenBacon()
            {
                Size = size

            };
            Assert.Equal(calories, tb.Calories);
        }

        [Theory]
        [InlineData(Size.Small, 1.50)]
        [InlineData(Size.Medium, 2.00)]
        [InlineData(Size.Large, 2.50)]
        public void PriceIsCorrectForSize(Size size, decimal price)
        {
            var tb = new TakenBacon()
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