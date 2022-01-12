/*
 * Author: Nathan Bean
 * File name: FlyingSaucerTests.cs
 * Purpose: Unit testing the FlyingSaucer class.
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
    /// Unit tests for the FlyingSaucer entree class
    /// </summary>
    public class FlyingSaucerTests
    {
        [Fact]
        public void NameShouldBeCorrect()
        {
            var fs = new FlyingSaucer();
            Assert.Equal("Flying Saucer", fs.Name);
        }

        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            var fs = new FlyingSaucer();
            string description = "Our namesake dish. A full stack of fluffy golden pancakes, served with whipped cream, butter and your choice of syrup.";
            Assert.Equal(description, fs.Description);
        }

        [Theory]
        [InlineData(false, 254)]
        [InlineData(true, 127)]
        public void ShouldHaveCorrectCaloriesForSize(bool halfStack, uint calories)
        {
            var fs = new FlyingSaucer()
            {
                HalfStack = halfStack
            };
            Assert.Equal(calories, fs.Calories);
        }

        [Theory]
        [InlineData(false, 5.50)]
        [InlineData(true, 3.25)]
        public void ShouldHaveCorrectPriceForSize(bool halfStack, decimal price)
        {
            var fs = new FlyingSaucer()
            {
                HalfStack = halfStack
            };
            Assert.Equal(price, fs.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetHalfStack(bool halfStack)
        {
            var fs = new FlyingSaucer();
            fs.HalfStack = halfStack;
            Assert.Equal(halfStack, fs.HalfStack);
        }

        [Theory]
        [InlineData(true, SyrupFlavor.Blackberry, new String[] { "Half Stack", "Blackberry Syrup" })]
        [InlineData(true, SyrupFlavor.Blueberry, new String[] { "Half Stack", "Blueberry Syrup" })]
        [InlineData(true, SyrupFlavor.Cherry, new String[] { "Half Stack", "Cherry Syrup" })]
        [InlineData(true, SyrupFlavor.Maple, new String[] { "Half Stack", "Maple Syrup" })]
        [InlineData(true, SyrupFlavor.Strawberry, new String[] { "Half Stack", "Strawberry Syrup" })]
        [InlineData(false, SyrupFlavor.Blackberry, new String[] { "Blackberry Syrup" })]
        [InlineData(false, SyrupFlavor.Blueberry, new String[] { "Blueberry Syrup" })]
        [InlineData(false, SyrupFlavor.Cherry, new String[] { "Cherry Syrup" })]
        [InlineData(false, SyrupFlavor.Maple, new String[] { "Maple Syrup" })]
        [InlineData(false, SyrupFlavor.Strawberry, new String[] { "Strawberry Syrup" })]
        public void ShouldProvideCurrentSpecialInstructions(bool halfStack, SyrupFlavor syrup, string[] instructions)
        {
            var fs = new FlyingSaucer()
            {
                HalfStack = halfStack,
                SyrupFlavor = syrup
            };
            foreach(string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, fs.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, fs.SpecialInstructions.Count);
        }



        [Theory]
        [InlineData("SyrupFlavor")]
        [InlineData("SpecialInstructions")]
        public void ChangeSyrupFlavor(string property)
        {
            FlyingSaucer cs = new FlyingSaucer();
            Assert.PropertyChanged(cs, property, () => { cs.SyrupFlavor = SyrupFlavor.Maple; });
        }

        [Theory]
        [InlineData("HalfStack")]
        [InlineData("SpecialInstructions")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangeHalfStack(string property)
        {
            FlyingSaucer cs = new FlyingSaucer();
            Assert.PropertyChanged(cs, property, () => { cs.HalfStack = true; });
        }
    }
}
