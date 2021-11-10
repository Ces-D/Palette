using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Logic;
using Xunit;

namespace Core.Tests
{
    public class ComplimentaryColorsTests
    {
        [Fact]
        public void White_complimentary_color_values_match()
        {
            var white = ColorBuilder.BuildFromHex("#ffffff");
            var builder = new ComplimentaryColorBuilder(white);
            var compliments = builder.Create();
            Assert.Equal("#FFFFFF", compliments.Primary.Hex.ToString());
            Assert.Equal("rgb(0, 0, 0)", compliments.Compliment.Rgb.ToString());
        }

        [Fact]
        public void Black_complimentary_color_values_match()
        {
            var black = ColorBuilder.BuildFromHsl("hsl(0, 0%, 0%)");
            var builder = new ComplimentaryColorBuilder(black);
            var compliments = builder.Create();
            Assert.Equal("hsv(0, 0%, 0%)", compliments.Primary.Hsv.ToString());
            Assert.Equal("rgb(255, 255, 255)", compliments.Compliment.Rgb.ToString());
        }

    }
}
