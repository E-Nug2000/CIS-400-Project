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
    /// Unit tests for the CropCircleOats class
    /// </summary>
    public class CropCircleOatsTests
    {
        [Fact]
        public void NameIsCorrectForSize()
        {
            var cco = new CropCircleOats();
            Assert.Equal(cco.Size.ToString() + " Crop Circle Oats", cco.Name);
        }

        [Fact]
        public void DescriptionIsCorrect()
        {
            var cco = new CropCircleOats();
            string description = "A hearty oatmeal doused in butter and your choice of syrup.";
            Assert.Equal(description, cco.Description);
        }

        [Theory]
        [InlineData(Size.Small, 158)]
        [InlineData(Size.Medium, 316)]
        [InlineData(Size.Large, 484)]
        public void CaloriesAreCorrectForSize(Size size, uint calories)
        {
            var cco = new CropCircleOats()
            {
                Size = size
                
            };
            Assert.Equal(calories, cco.Calories);
        }

        [Theory]
        [InlineData(Size.Small, 1.50)]
        [InlineData(Size.Medium, 2.00)]
        [InlineData(Size.Large, 2.50)]
        public void PriceIsCorrectForSize(Size size, decimal price)
        {
            var cco = new CropCircleOats();
            {
                cco.Size = size;

            };
            Assert.Equal(price, cco.Price);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetButter(bool butter)
        {
            var cco = new CropCircleOats();
            cco.Butter = butter;
            Assert.Equal(butter, cco.Butter);
        }

        [Theory]
        [InlineData(SyrupFlavor.Blackberry)]
        [InlineData(SyrupFlavor.Blueberry)]
        [InlineData(SyrupFlavor.Cherry)]
        [InlineData(SyrupFlavor.Maple)]
        [InlineData(SyrupFlavor.Strawberry)]
        public void ShouldBeAbleToSetSyrupFlavor(SyrupFlavor syrupFlavor)
        {
            var cco = new CropCircleOats();
            cco.SyrupFlavor = syrupFlavor;
            Assert.Equal(syrupFlavor, cco.SyrupFlavor);
        }

        [Theory]
        [InlineData(false, SyrupFlavor.Blackberry, new String[] { "Hold Butter", "Blackberry Syrup" })]
        [InlineData(false, SyrupFlavor.Blueberry, new String[] { "Hold Butter", "Blueberry Syrup" })]
        [InlineData(false, SyrupFlavor.Cherry, new String[] { "Hold Butter", "Cherry Syrup" })]
        [InlineData(false, SyrupFlavor.Maple, new String[] { "Hold Butter", "Maple Syrup" })]
        [InlineData(false, SyrupFlavor.Strawberry, new String[] { "Hold Butter", "Strawberry Syrup" })]
        [InlineData(true, SyrupFlavor.Blackberry, new String[] { "Blackberry Syrup" })]
        [InlineData(true, SyrupFlavor.Blueberry, new String[] { "Blueberry Syrup" })]
        [InlineData(true, SyrupFlavor.Cherry, new String[] { "Cherry Syrup" })]
        [InlineData(true, SyrupFlavor.Maple, new String[] { "Maple Syrup" })]
        [InlineData(true, SyrupFlavor.Strawberry, new String[] { "Strawberry Syrup" })]
        public void ShouldProvideCurrentSpecialInstructions(bool butter, SyrupFlavor syrup, string[] instructions)
        {
            var cco = new CropCircleOats()
            {
                Butter = butter,
                SyrupFlavor = syrup
            };
            foreach (string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, cco.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, cco.SpecialInstructions.Count);
        }

        [Theory]
        [InlineData("Size")]
        [InlineData("Name")]
        [InlineData("Calories")]
        [InlineData("Price")]
        public void CanChangeSize(string property)
        {
            CropCircleOats cco = new CropCircleOats();
            Assert.PropertyChanged(cco, property, () => { cco.Size = Size.Medium; });
            Assert.PropertyChanged(cco, property, () => { cco.Size = Size.Large; });
            Assert.PropertyChanged(cco, property, () => { cco.Size = Size.Small; });
        }

        [Theory]
        [InlineData("SyrupFlavor")]
        [InlineData("SpecialInstructions")]
        public void ChangeSyrupFlavor(string property)
        {
            CropCircleOats cco = new CropCircleOats();
            Assert.PropertyChanged(cco, property, () => { cco.SyrupFlavor = SyrupFlavor.Maple; });
        }

        [Theory]
        [InlineData("Butter")]
        [InlineData("SpecialInstructions")]
        public void ChangeHalfStack(string property)
        {
            CropCircleOats cco = new CropCircleOats();
            Assert.PropertyChanged(cco, property, () => { cco.Butter = true; });
        }
    }
}
