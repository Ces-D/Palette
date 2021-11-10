using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.ValueObjects;
using Xunit;

namespace Core.Tests
{
    public class HslValueTests
    {
        [Fact]
        public void Check_hue_saturation_lightness_values_for_white()
        {
            var hsl = Hsl.From("hsl(0, 0%, 100%)");
            Assert.Equal(0, hsl.Hue);
            Assert.Equal(0, hsl.Saturation);
            Assert.Equal(100, hsl.Lightness);
        }

        [Fact]
        public void Check_hue_saturation_lightness_values_for_black()
        {
            var hsl = Hsl.From("hsl(0, 0%, 0%)");
            Assert.Equal(0, hsl.Hue);
            Assert.Equal(0, hsl.Saturation);
            Assert.Equal(0, hsl.Lightness);
        }

        [Fact]
        public void Check_hue_saturation_lightness_values_for_random_1()
        {
            var hsl = Hsl.From("hsl(48, 58%, 58%)");
            Assert.Equal(48, hsl.Hue);
            Assert.Equal(58, hsl.Saturation);
            Assert.Equal(58, hsl.Lightness);
        }

        [Fact]
        public void Check_hue_saturation_lightness_values_for_random_2()
        {
            var hsl = Hsl.From("hsl(176, 42%, 71%)");
            Assert.Equal(176, hsl.Hue);
            Assert.Equal(42, hsl.Saturation);
            Assert.Equal(71, hsl.Lightness);
        }

        [Fact]
        public void Check_hue_saturation_lightness_values_for_random_3()
        {
            var hsl = Hsl.From("hsl(289, 100%, 52%)");
            Assert.Equal(289, hsl.Hue);
            Assert.Equal(100, hsl.Saturation);
            Assert.Equal(52, hsl.Lightness);
        }
    }
}
