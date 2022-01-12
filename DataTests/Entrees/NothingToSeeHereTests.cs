/*
 * Author: Nathan Bean
 * File name: NothingToSeeHereTests.cs
 * Purpose: Unit testing the NothingToSeeHere class.
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
    /// Unit tests for the NothingToSeeHere entree class
    /// </summary>
    public class NothingToSeeHereTests
    {
        [Fact]
        public void NameShouldBeCorrect()
        {
            var ntsh = new NothingToSeeHere();
            Assert.Equal("Nothing to See Here", ntsh.Name);
        }

        [Fact]
        public void DescriptionShouldBeCorrect()
        {
            var ntsh = new NothingToSeeHere();
            string description = "The breakfast classic of bacon, eggs, and Texas toast.";
            Assert.Equal(description, ntsh.Description);
        }

        [Theory]
        [InlineData(false, 512)]
        [InlineData(true, 543)]
        public void ShouldHaveCorrectCalories(bool substituteSausage, uint expectedCalories)
        {
            var ntsh = new NothingToSeeHere()
            {
                SubstituteSausage = substituteSausage
            };
            Assert.Equal(expectedCalories, ntsh.Calories);
        }

        [Fact]
        public void ShouldHaveCorrectPrice()
        {
            var ntsh = new NothingToSeeHere();
            Assert.Equal(3.50m, ntsh.Price);
        }

        [Theory]
        [InlineData(false, EggStyle.Scrambled, new string[] { "Eggs Scrambled" })]
        [InlineData(false, EggStyle.Poached, new string[] { "Eggs Poached" })]
        [InlineData(false, EggStyle.HardBoiled, new string[] { "Eggs Hard Boiled" })]
        [InlineData(false, EggStyle.SunnySideUp, new string[] { "Eggs Sunny Side Up" })]
        [InlineData(false, EggStyle.OverEasy, new string[] { "Eggs Over Easy" })]
        [InlineData(false, EggStyle.OverMedium, new string[] { "Eggs Over Medium" })]
        [InlineData(false, EggStyle.OverWell, new string[] { "Eggs Over Well" })]
        [InlineData(true, EggStyle.Scrambled, new string[] { "Substitute Sausage", "Eggs Scrambled" })]
        [InlineData(true, EggStyle.Poached, new string[] { "Substitute Sausage", "Eggs Poached" })]
        [InlineData(true, EggStyle.HardBoiled, new string[] { "Substitute Sausage", "Eggs Hard Boiled" })]
        [InlineData(true, EggStyle.SunnySideUp, new string[] { "Substitute Sausage", "Eggs Sunny Side Up" })]
        [InlineData(true, EggStyle.OverEasy, new string[] { "Substitute Sausage", "Eggs Over Easy" })]
        [InlineData(true, EggStyle.OverMedium, new string[] { "Substitute Sausage", "Eggs Over Medium" })]
        [InlineData(true, EggStyle.OverWell, new string[] { "Substitute Sausage", "Eggs Over Well" })]
        public void ShouldProvideCurrentSpecialInstructions(bool substituteSausage, EggStyle eggStyle, string[] instructions)
        {
            var ntsh = new NothingToSeeHere()
            {
                SubstituteSausage = substituteSausage,
                EggStyle = eggStyle
            };
            foreach (string expected in instructions)
            {
                Assert.Contains(expected, ntsh.SpecialInstructions);
            }
            Assert.Equal(instructions.Length, ntsh.SpecialInstructions.Count);
        }


        [Theory]
        [InlineData("EggStyle")]
        [InlineData("SpecialInstructions")]
        public void ChangeEggStyle(string property)
        {
            NothingToSeeHere entree = new NothingToSeeHere();
            Assert.PropertyChanged(entree, property, () => { entree.EggStyle = EggStyle.HardBoiled; });
        }

        [Theory]
        [InlineData("SubstituteSausage")]
        [InlineData("SpecialInstructions")]
        public void ChangeSausage(string property)
        {
            NothingToSeeHere entree = new NothingToSeeHere();
            Assert.PropertyChanged(entree, property, () => { entree.SubstituteSausage = false; });
        }
    }
}
