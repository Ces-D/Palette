using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.ValueObjects;
using Xunit;
namespace Core.Tests
{
    public class RgbValueTests
    {
        [Fact]
        public void Check_red_green_blue_values_for_white()
        {
            var rgb = Rgb.From("rgb(255, 255, 255)");
            Assert.Equal(255, rgb.Red);
            Assert.Equal(255, rgb.Green);
            Assert.Equal(255, rgb.Blue);
        }

        [Fact]
        public void Check_red_green_blue_values_for_black()
        {
            var rgb = Rgb.From("rgb(0, 0, 0)");
            Assert.Equal(0, rgb.Red);
            Assert.Equal(0, rgb.Green);
            Assert.Equal(0, rgb.Blue);
        }

        [Fact]
        public void Check_red_green_blue_values_for_random_1()
        {
            var rgb = Rgb.From("rgb(23, 145, 0)");
            Assert.Equal(23, rgb.Red);
            Assert.Equal(145, rgb.Green);
            Assert.Equal(0, rgb.Blue);
        }

        [Fact]
        public void Check_red_green_blue_values_for_random_2()
        {
            var rgb = Rgb.From("rgb(225, 215, 255)");
            Assert.Equal(225, rgb.Red);
            Assert.Equal(215, rgb.Green);
            Assert.Equal(255, rgb.Blue);
        }

        [Fact]
        public void Check_red_green_blue_values_for_random_3()
        {
            var rgb = Rgb.From("rgb(225, 5, 2)");
            Assert.Equal(225, rgb.Red);
            Assert.Equal(5, rgb.Green);
            Assert.Equal(2, rgb.Blue);
        }
    }
}
