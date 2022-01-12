/*
 * Author: Edward Gruver
 * File name: LiquifiedVegetationTests.cs
 * Purpose: Unit testing LiquifiedVegetation class
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
    /// Tests for the LiquifiedVegetation class
    /// </summary>
    public class LiquifiedVegetationTests
    {
        [Fact]
        public void NameIsCorrectForSize()
        {
            var cco = new LiquifiedVegetation();
            Assert.Equal(cco.Size.ToString() + " Liquified Vegetation", cco.Name);
        }

        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            var cs = new LiquifiedVegetation();
            string description = "Fresh juice extracted from the finest fruits and vegetables.";
            Assert.Equal(description, cs.Description);
        }


        [Theory]
        [InlineData(Size.Small, JuiceFlavor.Apple, 113u)]
        [InlineData(Size.Medium, JuiceFlavor.Apple, 226u)]
        [InlineData(Size.Large, JuiceFlavor.Apple, 339u)]
        [InlineData(Size.Small, JuiceFlavor.Cranberry, 117u)]
        [InlineData(Size.Medium, JuiceFlavor.Cranberry, 234u)]
        [InlineData(Size.Large, JuiceFlavor.Cranberry, 481u)]
        [InlineData(Size.Small, JuiceFlavor.Grape, 152u)]
        [InlineData(Size.Medium, JuiceFlavor.Grape, 234u)]
        [InlineData(Size.Large, JuiceFlavor.Grape, 481u)]
        [InlineData(Size.Small, JuiceFlavor.Orange, 111u)]
        [InlineData(Size.Medium, JuiceFlavor.Orange, 222u)]
        [InlineData(Size.Large, JuiceFlavor.Orange, 333u)]
        [InlineData(Size.Small, JuiceFlavor.Tomato, 42u)]
        [InlineData(Size.Medium, JuiceFlavor.Tomato, 84u)]
        [InlineData(Size.Large, JuiceFlavor.Tomato, 126u)]
        public void CaloriesAreCorrectForSizeAndFlavor(Size size, JuiceFlavor flavor, uint calories)
        {
            var cco = new LiquifiedVegetation()
            {
                Size = size,
                JuiceFlavor = flavor

            };
            Assert.Equal(calories, cco.Calories);
        }


        [Theory]
        [InlineData(JuiceFlavor.Apple, new String[] { "Apple Juice" })]
        [InlineData(JuiceFlavor.Cranberry, new String[] { "Cranberry Juice" })]
        [InlineData(JuiceFlavor.Grape, new String[] { "Grape Juice" })]
        [InlineData(JuiceFlavor.Orange, new String[] { "Orange Juice" })]
        [InlineData(JuiceFlavor.Tomato, new String[] { "Tomato Juice" })]
        public void ShouldProvideCurrentSpecialInstructions(JuiceFlavor flavor, string[] instructions)
        {
            var cco = new LiquifiedVegetation()
            {
                JuiceFlavor = flavor
            };
            foreach (string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, cco.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, cco.SpecialInstructions.Count);
        }

        [Theory]
        [InlineData(Size.Small, 1.00)]
        [InlineData(Size.Medium, 1.50)]
        [InlineData(Size.Large, 2.00)]
        public void PriceIsCorrectForSize(Size size, decimal price)
        {
            var cco = new LiquifiedVegetation();
            {
                cco.Size = size;

            };
            Assert.Equal(price, cco.Price);
        }

        [Fact]
        public void ShouldBeAssignableToAbstractIOrderItemClass()
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.IsAssignableFrom<IOrderItem>(drink);
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
        [InlineData("JuiceFlavor")]
        [InlineData("SpecialInstructions")]
        public void CanChangeJuiceFlavor(string property)
        {
            LiquifiedVegetation drink = new LiquifiedVegetation();
            Assert.PropertyChanged(drink, property, () => { drink.JuiceFlavor = JuiceFlavor.Apple; });
        }



    }
}
