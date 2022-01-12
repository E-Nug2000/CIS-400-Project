/*
 * Author: Edward Gruver
 * File name: YoureToastTests.cs
 * Purpose: Unit testing the YoureToast class
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
    /// Unit tests for the YoureToast class
    /// </summary>
    public class YoureToastTests
    {
        [Fact]
        public void NameIsCorrectForSize()
        {
            var yt = new YoureToast();
            Assert.Equal(yt.Size.ToString() + " You're Toast!", yt.Name);
        }

        [Fact]
        public void DescriptionIsCorrect()
        {
            var yt = new YoureToast();
            string description = "Thick, crusty slabs of Texas Toast.";
            Assert.Equal(description, yt.Description);
        }

        [Theory]
        [InlineData(Size.Small, 100)]
        [InlineData(Size.Medium, 200)]
        [InlineData(Size.Large, 300)]
        public void CaloriesAreCorrectForSize(Size size, uint calories)
        {
            var yt = new YoureToast()
            {
                Size = size

            };
            Assert.Equal(calories, yt.Calories);
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