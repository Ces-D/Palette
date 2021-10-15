using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.ValueObjects;
using Xunit;

namespace Core.Tests
{
    public class HexValueTests
    {
        [Fact]
        public void Check_red_green_blue_values_for_white()
        {
            var hex = Hex.From("#ffffff");
            Assert.Equal("FF", hex.Red);
            Assert.Equal("FF", hex.Green);
            Assert.Equal("FF", hex.Blue);
        }

        [Fact]
        public void Check_red_green_blue_values_for_black()
        {
            var hex = Hex.From("#000000");
            Assert.Equal("00", hex.Red);
            Assert.Equal("00", hex.Green);
            Assert.Equal("00", hex.Blue);
        }

        [Fact]
        public void Check_red_green_blue_values_for_random_1()
        {
            var hex = Hex.From("#367cd1");
            Assert.Equal("36", hex.Red);
            Assert.Equal("7C", hex.Green);
            Assert.Equal("D1", hex.Blue);
        }

        [Fact]
        public void Check_red_green_blue_values_for_random_2()
        {
            var hex = Hex.From("#c0b791");
            Assert.Equal("C0", hex.Red);
            Assert.Equal("B7", hex.Green);
            Assert.Equal("91", hex.Blue);
        }

        [Fact]
        public void Check_red_green_blue_values_for_random_3()
        {
            var hex = Hex.From("#f223f5");
            Assert.Equal("F2", hex.Red);
            Assert.Equal("23", hex.Green);
            Assert.Equal("F5", hex.Blue);
        }
    }
}
