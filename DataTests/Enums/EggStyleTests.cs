/*
 * Author: Nathan Bean
 * File name: EggStyleTests.cs
 * Purpose: Unit testing the EggStyle enumeration.
 */
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TheFlyingSaucer.Data.Enums;

namespace TheFlyingSaucer.DataTests.Enums
{
    /// <summary>
    /// A class containing unit tests for the EggStyle enumeration
    /// </summary>
    public class EggStyleTests
    {
        [Theory]
        [InlineData("Scrambled")]
        [InlineData("Poached")]
        [InlineData("HardBoiled")]
        [InlineData("SunnySideUp")]
        [InlineData("OverEasy")]
        [InlineData("OverMedium")]
        [InlineData("OverWell")]
        public void HasExpectedAttributes(string expected)
        {
            Assert.Contains(Enum.GetNames(typeof(EggStyle)), actual => actual == expected);
        }

        [Fact]
        public void HasThreeAttributes()
        {
            Assert.Equal(7, Enum.GetNames(typeof(EggStyle)).Length);
        }
    }
}
