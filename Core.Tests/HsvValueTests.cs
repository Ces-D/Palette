using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.ValueObjects;
using Xunit;

namespace Core.Tests
{
    public class HsvValueTests
    {
        [Fact]
        public void Check_hue_saturation_value_values_for_white()
        {
            var hsv = Hsv.From("hsv(0, 0%, 100%)");
            Assert.Equal(0, hsv.Hue);
            Assert.Equal(0, hsv.Saturation);
            Assert.Equal(100, hsv.Value);
        }

        [Fact]
        public void Check_hue_saturation_value_values_for_black()
        {
            var hsv = Hsv.From("hsv(0, 0%, 0%)");
            Assert.Equal(0, hsv.Hue);
            Assert.Equal(0, hsv.Saturation);
            Assert.Equal(0, hsv.Value);
        }

        [Fact]
        public void Check_hue_saturation_value_values_for_random_1()
        {
            var hsv = Hsv.From("hsv(163, 89%, 100%)");
            Assert.Equal(163, hsv.Hue);
            Assert.Equal(89, hsv.Saturation);
            Assert.Equal(100, hsv.Value);
        }

        [Fact]
        public void Check_hue_saturation_value_values_for_random_2()
        {
            var hsv = Hsv.From("hsv(28, 45%, 38%)");
            Assert.Equal(28, hsv.Hue);
            Assert.Equal(45, hsv.Saturation);
            Assert.Equal(38, hsv.Value);
        }

        [Fact]
        public void Check_hue_saturation_value_values_for_random_3()
        {
            var hsv = Hsv.From("hsv(274, 86%, 38%)");
            Assert.Equal(274, hsv.Hue);
            Assert.Equal(86, hsv.Saturation);
            Assert.Equal(38, hsv.Value);
        }
    }
}
