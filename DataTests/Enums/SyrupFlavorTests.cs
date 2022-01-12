/*
 * Author: Nathan Bean
 * File name: SyrupFlavorTests.cs
 * Purpose: Unit testing the SyrupFlavor enumeration
 */
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TheFlyingSaucer.Data.Enums;

namespace TheFlyingSaucer.DataTests.Enums
{
    /// <summary>
    /// A class containing unit tests for the SyrupFlavor enumeration
    /// </summary>
    public class SyrupFlavorTests
    {
        [Theory]
        [InlineData("Maple")]
        [InlineData("Cherry")]
        [InlineData("Blueberry")]
        [InlineData("Blackberry")]
        [InlineData("Strawberry")]
        public void HasExpectedAttributes(string expected)
        {
            Assert.Contains(Enum.GetNames(typeof(SyrupFlavor)), actual => actual == expected);
        }

        [Fact]
        public void HasThreeAttributes()
        {
            Assert.Equal(5, Enum.GetNames(typeof(SyrupFlavor)).Length);
        }
    }
}
