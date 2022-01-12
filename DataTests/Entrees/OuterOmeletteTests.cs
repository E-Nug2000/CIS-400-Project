/*
 * Author: Nathan Bean
 * File name: OuterOmeletteTests.cs
 * Purpose: Unit testing the OuterOmelette class.
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
    /// Unit tests for the OuterOmlette entree class
    /// </summary>
    public class OuterOmeletteTests
    {
        [Fact]
        public void NameShouldBeCorrect()
        {
            var oo = new OuterOmelette();
            Assert.Equal("Outer Omelette", oo.Name);
        }

        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            var oo = new OuterOmelette();
            string description = "A loaded omelette stuffed with all the favorites.";
            Assert.Equal(description, oo.Description);
        }

        [Fact]
        public void ShouldHaveCorrectCalories()
        {
            var oo = new OuterOmelette();
            Assert.Equal(510u, oo.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectPrice()
        {
            var oo = new OuterOmelette();
            Assert.Equal(5.80m, oo.Price);
        }

        [Fact]
        public void ShouldBeAbleToSetTomatoes()
        {
            var oo = new OuterOmelette();
            oo.Tomatoes = false;
            Assert.False(oo.Tomatoes);
            oo.Tomatoes = true;
            Assert.True(oo.Tomatoes);
        }

        [Fact]
        public void ShouldBeAbleToSetMushrooms()
        {
            var oo = new OuterOmelette();
            oo.Mushrooms = false;
            Assert.False(oo.Mushrooms);
            oo.Mushrooms = true;
            Assert.True(oo.Mushrooms);
        }

        [Fact]
        public void ShouldBeAbleToSetPeppers()
        {
            var oo = new OuterOmelette();
            oo.Peppers = false;
            Assert.False(oo.Peppers);
            oo.Peppers = true;
            Assert.True(oo.Peppers);
        }

        [Fact]
        public void ShouldBeAbleToSetOnions()
        {
            var oo = new OuterOmelette();
            oo.Onions = false;
            Assert.False(oo.Onions);
            oo.Onions = true;
            Assert.True(oo.Onions);
        }

        [Fact]
        public void ShouldBeAbleToSetSpinach()
        {
            var oo = new OuterOmelette();
            oo.Spinach = false;
            Assert.False(oo.Spinach);
            oo.Spinach = true;
            Assert.True(oo.Spinach);
        }

        [Fact]
        public void ShouldBeAbleToSetHam()
        {
            var oo = new OuterOmelette();
            oo.Ham = false;
            Assert.False(oo.Ham);
            oo.Ham = true;
            Assert.True(oo.Ham);
        }

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            var oo = new OuterOmelette();
            oo.Cheese = false;
            Assert.False(oo.Cheese);
            oo.Cheese = true;
            Assert.True(oo.Cheese);
        }

        [Fact]
        public void ShouldBeAbleToSetSourCream()
        {
            var oo = new OuterOmelette();
            oo.SourCream = false;
            Assert.False(oo.SourCream);
            oo.SourCream = true;
            Assert.True(oo.SourCream);
        }

        [Fact]
        public void ShouldHaveAllIngredientsByDefault()
        {
            var oo = new OuterOmelette();
            Assert.True(oo.Tomatoes, "Expected Tomatoes");
            Assert.True(oo.Mushrooms, "Expected Mushrooms");
            Assert.True(oo.Peppers, "Expected Peppers");
            Assert.True(oo.Onions, "Expected Onions");
            Assert.True(oo.Spinach, "Expected Spinach");
            Assert.True(oo.Ham, "Expected Ham");
            Assert.True(oo.Cheese, "Expected Cheese");
            Assert.True(oo.SourCream, "Expected Sour Cream");
        }
        
        [Theory]
        [InlineData(true, true, true, true, true, true, true, true, new String[] { })]
        [InlineData(false, true, true, true, true, true, true, true, new String[] { "Hold Tomatoes" })]
        [InlineData(true, false, true, true, true, true, true, true, new String[] { "Hold Mushrooms" })]
        [InlineData(true, true, false, true, true, true, true, true, new String[] { "Hold Peppers" })]
        [InlineData(true, true, true, false, true, true, true, true, new String[] { "Hold Onions" })]
        [InlineData(true, true, true, true, false, true, true, true, new String[] { "Hold Spinach" })]
        [InlineData(true, true, true, true, true, false, true, true, new String[] { "Hold Ham" })]
        [InlineData(true, true, true, true, true, true, false, true, new String[] { "Hold Cheese" })]
        [InlineData(true, true, true, true, true, true, true, false, new String[] { "Hold Sour Cream" })]
        [InlineData(true, false, false, false, false, true, true, true, new String[] { "Hold Mushrooms", "Hold Peppers", "Hold Onions", "Hold Spinach" })]
        [InlineData(true, true, true, true, false, false, true, false, new String[] { "Hold Spinach", "Hold Ham", "Hold Sour Cream" })]
        [InlineData(false, false, false, false, false, false, false, false, new String[] { "Hold Tomatoes", "Hold Mushrooms", "Hold Peppers", "Hold Onions", "Hold Spinach", "Hold Ham", "Hold Cheese", "Hold Sour Cream" })]
        public void ShouldProvideCurrentSpecialInstructions(bool tomatoes, bool mushrooms, bool peppers, bool onions, bool spinach, bool ham, bool cheese, bool sourcream, string[] instructions)
        {
            var oo = new OuterOmelette()
            {
                Tomatoes = tomatoes,
                Mushrooms = mushrooms,
                Peppers = peppers,
                Onions = onions,
                Spinach = spinach,
                Ham = ham,
                Cheese = cheese,
                SourCream = sourcream
            };
            foreach (string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, oo.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, oo.SpecialInstructions.Count);
        }


        [Theory]
        [InlineData("Tomatoes")]
        [InlineData("SpecialInstructions")]
        public void CanChangeTomatoes(string property)
        {
            OuterOmelette oo = new OuterOmelette();
            Assert.PropertyChanged(oo, property, () => { oo.Tomatoes = false; });

        }

        [Theory]
        [InlineData("Mushrooms")]
        [InlineData("SpecialInstructions")]
        public void CanChangeMushrooms(string property)
        {
            OuterOmelette oo = new OuterOmelette();
            Assert.PropertyChanged(oo, property, () => { oo.Mushrooms = false; });

        }

        [Theory]
        [InlineData("Peppers")]
        [InlineData("SpecialInstructions")]
        public void CanChangePeppers(string property)
        {
            OuterOmelette oo = new OuterOmelette();
            Assert.PropertyChanged(oo, property, () => { oo.Peppers = false; });

        }

        [Theory]
        [InlineData("Onions")]
        [InlineData("SpecialInstructions")]
        public void CanChangeOnions(string property)
        {
            OuterOmelette oo = new OuterOmelette();
            Assert.PropertyChanged(oo, property, () => { oo.Onions= false; });

        }

        [Theory]
        [InlineData("Spinach")]
        [InlineData("SpecialInstructions")]
        public void CanChangeSpinach(string property)
        {
            OuterOmelette oo = new OuterOmelette();
            Assert.PropertyChanged(oo, property, () => { oo.Spinach = false; });

        }

        [Theory]
        [InlineData("Ham")]
        [InlineData("SpecialInstructions")]
        public void CanChangeHam(string property)
        {
            OuterOmelette oo = new OuterOmelette();
            Assert.PropertyChanged(oo, property, () => { oo.Ham = false; });

        }

        [Theory]
        [InlineData("Cheese")]
        [InlineData("SpecialInstructions")]
        public void CanChangeCheese(string property)
        {
            OuterOmelette oo = new OuterOmelette();
            Assert.PropertyChanged(oo, property, () => { oo.Cheese = false; });

        }

        [Theory]
        [InlineData("SourCream")]
        [InlineData("SpecialInstructions")]
        public void CanChangeSourCream(string property)
        {
            OuterOmelette oo = new OuterOmelette();
            Assert.PropertyChanged(oo, property, () => { oo.SourCream = false; });

        }

    }
}
