using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palette.Core.Infrastructure.Models;
using Palette.Core.Infrastructure.Models.Colors;
using Xunit;

namespace Palette.Core.Tests.Colors
{
    public class ColorHarmonyTests
    {
        [Fact]
        public void Check_complimentary_color_for_white()
        {
            Rgb primaryRgb = new(255, 255, 255);
            Color primary = new(primaryRgb);
            ColorHarmonies colors = new(primary);

            List<Color> colorCompliments = colors.Complimentary();

            Assert.Equal("rgb(255, 255, 255)", colorCompliments[1].Rgb.Color);
            Assert.Equal("hsv(0, 0%, 100%)", colorCompliments[1].Hsv.Color);
            Assert.Equal("rgb(255, 255, 255)", colorCompliments[0].Rgb.Color);
            Assert.Equal("hsv(0, 0%, 100%)", colorCompliments[0].Hsv.Color);
        }

        [Fact]
        public void Check_complimentary_color_for_black()
        {
            Rgb primaryRgb = new(0, 0, 0);
            Color primary = new(primaryRgb);
            ColorHarmonies colors = new(primary);

            List<Color> colorCompliments = colors.Complimentary();

            Assert.Equal("rgb(0, 0, 0)", colorCompliments[1].Rgb.Color);
            Assert.Equal("hsv(0, 0%, 0%)", colorCompliments[1].Hsv.Color);
            Assert.Equal("rgb(0, 0, 0)", colorCompliments[0].Rgb.Color);
            Assert.Equal("hsv(0, 0%, 0%)", colorCompliments[0].Hsv.Color);
        }

        [Fact]
        public void Check_complimentary_color_for_red()
        {
            Rgb primaryRgb = new(228, 52, 96);
            Color primary = new(primaryRgb);
            ColorHarmonies colors = new(primary);

            List<Color> colorCompliments = colors.Complimentary();

            Assert.Equal("rgb(52, 227, 224)", colorCompliments[1].Rgb.Color);
            Assert.Equal("hsv(179, 77%, 89%)", colorCompliments[1].Hsv.Color);
            Assert.Equal("rgb(228, 52, 96)", colorCompliments[0].Rgb.Color);
            Assert.Equal("hsv(359, 77%, 89%)", colorCompliments[0].Hsv.Color);
        }

        [Fact]
        public void Check_complimentary_color_for_green()
        {
            Rgb primaryRgb = new(35, 70, 70);
            Color primary = new(primaryRgb);
            ColorHarmonies colors = new(primary);

            List<Color> colorCompliments = colors.Complimentary();

            Assert.Equal("rgb(69, 34, 34)", colorCompliments[1].Rgb.Color);
            Assert.Equal("hsv(0, 50%, 27%)", colorCompliments[1].Hsv.Color);
            Assert.Equal("rgb(35, 70, 70)", colorCompliments[0].Rgb.Color);
            Assert.Equal("hsv(180, 50%, 27%)", colorCompliments[0].Hsv.Color);
        }

        [Fact]
        public void Check_complimentary_color_for_blue()
        {
            Rgb primaryRgb = new(109, 36, 188);
            Color primary = new(primaryRgb);
            ColorHarmonies colors = new(primary);

            List<Color> colorCompliments = colors.Complimentary();

            Assert.Equal("rgb(37, 186, 181)", colorCompliments[1].Rgb.Color);
            Assert.Equal("hsv(178, 80%, 73%)", colorCompliments[1].Hsv.Color);
            Assert.Equal("rgb(109, 36, 188)", colorCompliments[0].Rgb.Color);
            Assert.Equal("hsv(358, 80%, 73%)", colorCompliments[0].Hsv.Color);
        }
    }
}
