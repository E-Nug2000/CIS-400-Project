/*
 * Author: Nathan Bean
 * File name: CrashedSaucerTests.cs
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
    /// Unit tests for the CrashedSaucer entree
    /// </summary>
    public class CrashedSaucerTests
    {
        [Fact]
        public void NameShouldBeCorrect()
        {
            var cs = new CrashedSaucer();
            Assert.Equal("Crashed Saucer", cs.Name);
        }

        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            var cs = new CrashedSaucer();
            string description = "A stack of thick-sliced french toast, served with whipped cream, butter and your choice of syrup.";
            Assert.Equal(description, cs.Description);
        }

        [Theory]
        [InlineData(false, 510)]
        [InlineData(true, 255)]
        public void ShouldHaveCorrectCaloriesForSize(bool halfStack, uint calories)
        {
            var cs = new CrashedSaucer()
            {
                HalfStack = halfStack
            };
            Assert.Equal(calories, cs.Calories);
        }

        [Theory]
        [InlineData(false, 5.80)]
        [InlineData(true, 3.70)]
        public void ShouldHaveCorrectPriceForSize(bool halfStack, decimal price)
        {
            var cs = new CrashedSaucer()
            {
                HalfStack = halfStack
            };
            Assert.Equal(price, cs.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetHalfStack(bool halfStack)
        {
            var cs = new CrashedSaucer();
            cs.HalfStack = halfStack;
            Assert.Equal(halfStack, cs.HalfStack);
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
            var cs = new CrashedSaucer()
            {
                HalfStack = halfStack,
                SyrupFlavor = syrup
            };
            foreach(string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, cs.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, cs.SpecialInstructions.Count);
        }

        [Theory]
        [InlineData("SyrupFlavor")]
        [InlineData("SpecialInstructions")]
        public void ChangeSyrupFlavor(string property)
        {
            CrashedSaucer cs = new CrashedSaucer();
            Assert.PropertyChanged(cs, property, () => { cs.SyrupFlavor = SyrupFlavor.Maple; });
        }

        [Theory]
        [InlineData("HalfStack")]
        [InlineData("SpecialInstructions")]
        [InlineData("Price")]
        [InlineData("Calories")]
        public void ChangeHalfStack(string property)
        {
            CrashedSaucer cs = new CrashedSaucer();
            Assert.PropertyChanged(cs, property, () => { cs.HalfStack = true; });
        }



    }
}
