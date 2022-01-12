/*
 * Author: Nathan Bean
 * File name: SpaceScrambleTests.cs
 * Purpose: Unit testing the SpaceScramble class.
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
    /// Unit tests for the SpaceScramble entree class
    /// </summary>
    public class SpaceScrambleTests
    {

        [Fact]
        public void NameShouldBeCorrect()
        {
            var ss = new SpaceScramble();
            Assert.Equal("Space Scramble", ss.Name);
        }

        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            var ss = new SpaceScramble();
            string description = "A hearty skillet-fried scramble of potatoes, sausage, peppers, jack cheddar cheese, sour cream, and topped with your choice of egg.";
            Assert.Equal(description, ss.Description);
        }

        [Fact]
        public void ShouldHaveCorrectCalories()
        {
            var ss = new SpaceScramble();
            Assert.Equal(380u, ss.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectPrice()
        {
            var ss = new SpaceScramble();
            Assert.Equal(5.20m, ss.Price);
        }

        [Fact]
        public void ShouldBeAbleToSetPotatoes()
        {
            var ss = new SpaceScramble();
            ss.Potatoes = false;
            Assert.False(ss.Potatoes);
            ss.Potatoes = true;
            Assert.True(ss.Potatoes);
        }

        [Fact]
        public void ShouldBeAbleToSetSausage()
        {
            var ss = new SpaceScramble();
            ss.Sausage = false;
            Assert.False(ss.Sausage);
            ss.Sausage = true;
            Assert.True(ss.Sausage);
        }

        [Fact]
        public void ShouldBeAbleToSetPeppers()
        {
            var ss = new SpaceScramble();
            ss.Peppers = false;
            Assert.False(ss.Peppers);
            ss.Peppers = true;
            Assert.True(ss.Peppers);
        }

        [Fact]
        public void ShouldBeAbleToSetCheese()
        {
            var ss = new SpaceScramble();
            ss.Cheese = false;
            Assert.False(ss.Cheese);
            ss.Cheese = true;
            Assert.True(ss.Cheese);
        }

        [Fact]
        public void ShouldBeAbleToSetSourCream()
        {
            var ss = new SpaceScramble();
            ss.SourCream = false;
            Assert.False(ss.SourCream);
            ss.SourCream = true;
            Assert.True(ss.SourCream);
        }

        [Fact]
        public void ShouldBeAbleToSetEgg()
        {
            var ss = new SpaceScramble();
            ss.Egg = false;
            Assert.False(ss.Egg);
            ss.Egg = true;
            Assert.True(ss.Egg);
        }

        [Fact]
        public void ShouldHaveAllIngredientsByDefault()
        {
            var ss = new SpaceScramble();
            Assert.True(ss.Potatoes, "Expected Potatoes");
            Assert.True(ss.Sausage, "Expected Sausage");
            Assert.True(ss.Peppers, "Expected Peppers");
            Assert.True(ss.Cheese, "Expected Cheese");
            Assert.True(ss.SourCream, "Expected Sour Cream");
            Assert.True(ss.Egg, "Expeted Egg");
        }
    
        [Theory]
        [InlineData(true, true, true, true, true, true, EggStyle.Scrambled, new String[] { "Eggs Scrambled" })]
        [InlineData(true, true, true, true, true, true, EggStyle.Poached, new String[] { "Eggs Poached" })]
        [InlineData(true, true, true, true, true, true, EggStyle.HardBoiled, new String[] { "Eggs Hard Boiled" })]
        [InlineData(true, true, true, true, true, true, EggStyle.SunnySideUp, new String[] { "Eggs Sunny Side Up" })]
        [InlineData(true, true, true, true, true, true, EggStyle.OverEasy, new String[] { "Eggs Over Easy" })]
        [InlineData(true, true, true, true, true, true, EggStyle.OverMedium, new String[] { "Eggs Over Medium" })]
        [InlineData(true, true, true, true, true, true, EggStyle.OverWell, new String[] { "Eggs Over Well" })]
        [InlineData(false, true, true, true, true, true, EggStyle.Scrambled, new String[] { "Hold Potatoes", "Eggs Scrambled" })]
        [InlineData(true, false, true, true, true, true, EggStyle.Scrambled, new String[] { "Hold Sausage", "Eggs Scrambled" })]
        [InlineData(true, true, false, true, true, true, EggStyle.Scrambled, new String[] { "Hold Peppers", "Eggs Scrambled" })]
        [InlineData(true, true, true, false, true, true, EggStyle.Scrambled, new String[] { "Hold Cheese", "Eggs Scrambled" })]
        [InlineData(true, true, true, true, false, true, EggStyle.Scrambled, new String[] { "Hold Sour Cream", "Eggs Scrambled" })]
        [InlineData(true, true, true, true, true, false, EggStyle.Scrambled, new String[] { "Hold Egg" })]
        [InlineData(false, true, true, true, true, true, EggStyle.Poached, new String[] { "Hold Potatoes", "Eggs Poached" })]
        [InlineData(true, false, true, true, true, true, EggStyle.OverEasy, new String[] { "Hold Sausage", "Eggs Over Easy" })]
        [InlineData(true, true, false, true, true, true, EggStyle.SunnySideUp, new String[] { "Hold Peppers", "Eggs Sunny Side Up" })]
        [InlineData(true, true, true, false, true, true, EggStyle.OverWell, new String[] { "Hold Cheese", "Eggs Over Well" })]
        [InlineData(true, true, true, true, false, true, EggStyle.OverMedium, new String[] { "Hold Sour Cream", "Eggs Over Medium" })]
        [InlineData(true, true, true, true, true, false, EggStyle.OverEasy, new String[] { "Hold Egg" })]
        [InlineData(true, false, false, false, false, true, EggStyle.Scrambled, new String[] { "Hold Sausage", "Hold Peppers", "Hold Cheese", "Hold Sour Cream", "Eggs Scrambled" })]
        [InlineData(true, true, true, true, false, false, EggStyle.Scrambled, new String[] { "Hold Sour Cream", "Hold Egg" })]
        [InlineData(false, false, false, false, false, false, EggStyle.Scrambled, new String[] { "Hold Potatoes", "Hold Sausage", "Hold Peppers", "Hold Cheese", "Hold Sour Cream", "Hold Egg" })]
        public void ShouldProvideCurrentSpecialInstructions(bool potatoes, bool sausage, bool peppers, bool cheese, bool sourcream, bool egg, EggStyle eggStyle, string[] instructions)
        {
            var ss = new SpaceScramble()
            {
                Potatoes = potatoes,
                Sausage = sausage,
                Peppers = peppers,                
                Cheese = cheese,
                SourCream = sourcream,
                Egg = egg,
                EggStyle = eggStyle
            };
            foreach (string expectedInstruction in instructions)
            {
                Assert.Contains(expectedInstruction, ss.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, ss.SpecialInstructions.Count);
        }


        [Theory]
        [InlineData("Peppers")]
        [InlineData("SpecialInstructions")]
        public void CanChangePeppers(string property)
        {
            SpaceScramble ss = new SpaceScramble();
            Assert.PropertyChanged(ss, property, () => { ss.Peppers = false; });

        }


        [Theory]
        [InlineData("Potatoes")]
        [InlineData("SpecialInstructions")]
        public void CanChangePotatoes(string property)
        {
            SpaceScramble ss = new SpaceScramble();
            Assert.PropertyChanged(ss, property, () => { ss.Potatoes = false; });

        }

        [Theory]
        [InlineData("Sausage")]
        [InlineData("SpecialInstructions")]
        public void CanChangeSausage(string property)
        {
            SpaceScramble ss = new SpaceScramble();
            Assert.PropertyChanged(ss, property, () => { ss.Sausage = false; });

        }

        [Theory]
        [InlineData("Cheese")]
        [InlineData("SpecialInstructions")]
        public void CanChangeCheese(string property)
        {
            SpaceScramble ss = new SpaceScramble();
            Assert.PropertyChanged(ss, property, () => { ss.Cheese = false; });

        }

        [Theory]
        [InlineData("SourCream")]
        [InlineData("SpecialInstructions")]
        public void CanChangeSourCream(string property)
        {
            SpaceScramble ss = new SpaceScramble();
            Assert.PropertyChanged(ss, property, () => { ss.SourCream = false; });

        }


        [Theory]
        [InlineData("EggStyle")]
        [InlineData("SpecialInstructions")]
        public void ChangeEggStyle(string property)
        {
            SpaceScramble ss = new SpaceScramble();
            Assert.PropertyChanged(ss, property, () => { ss.EggStyle = EggStyle.HardBoiled; });
        }

    }
}
