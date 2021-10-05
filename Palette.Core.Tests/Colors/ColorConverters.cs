using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palette.Core.Infrastructure;
using Palette.Core.Infrastructure.Models.Colors;
using Xunit;

namespace Palette.Core.Tests.Colors
{
    public class ColorConverters
    {
        [Fact]
        public void Check_hex_to_rgb_converter_white()
        {
            Hex hex = new("#FFFFFF");
            var rgb = ConvertColor.ToRgb(hex);
            Assert.Equal("rgb(255, 255, 255)", rgb.Color);
        }

        [Fact]
        public void Check_hex_to_rgb_converter_black()
        {
            Hex hex = new("#000000");
            var rgb = ConvertColor.ToRgb(hex);
            Assert.Equal("rgb(0, 0, 0)", rgb.Color);
        }

        [Fact]
        public void Check_hex_to_rgb_converter_red()
        {
            Hex hex = new("#f22598");
            var rgb = ConvertColor.ToRgb(hex);
            Assert.Equal("rgb(242, 37, 152)", rgb.Color);
        }

        [Fact]
        public void Check_hex_to_rgb_converter_blue()
        {
            Hex hex = new("#128495");
            var rgb = ConvertColor.ToRgb(hex);
            Assert.Equal("rgb(18, 132, 149)", rgb.Color);
        }

        [Fact]
        public void Check_hsv_to_rgb_converter_white()
        {
            Hsv hsv = new(0, 0, 100);
            var rgb = ConvertColor.ToRgb(hsv);
            Assert.Equal("rgb(255, 255, 255)", rgb.Color);
        }

        [Fact]
        public void Check_hsv_to_rgb_converter_black()
        {
            Hsv hsv = new(0, 0, 0);
            var rgb = ConvertColor.ToRgb(hsv);
            Assert.Equal("rgb(0, 0, 0)", rgb.Color);
        }

        [Fact]
        public void Check_hsv_to_rgb_converter_red()
        {
            Hsv hsv = new(0, 81, 97);
            var rgb = ConvertColor.ToRgb(hsv);
            Assert.Equal("rgb(247, 47, 47)", rgb.Color);
        }

        [Fact]
        public void Check_hsv_to_rgb_converter_blue()
        {
            Hsv hsv = new(237, 34, 95);
            var rgb = ConvertColor.ToRgb(hsv);
            Assert.Equal("rgb(160, 164, 242)", rgb.Color);
        }

        [Fact]
        public void Check_rgb_to_hsv_converter_white()
        {
            Rgb rgb = new(255, 255, 255);
            var hsv = ConvertColor.ToHsv(rgb);
            Assert.Equal("hsv(0, 0%, 100%)", hsv.Color);
        }

        [Fact]
        public void Check_rgb_to_hsv_converter_black() {
            Rgb rgb = new(0, 0, 0);
            var hsv = ConvertColor.ToHsv(rgb);
            Assert.Equal("hsv(0, 0%, 0%)", hsv.Color);
        }

        [Fact]
        public void Check_rgb_to_hsv_converter_red() {
            Rgb rgb = new(222, 206, 81);
            var hsv = ConvertColor.ToHsv(rgb);
            Assert.Equal("hsv(54, 64%, 87%)", hsv.Color);
        }
        [Fact]
        public void Check_rgb_to_hsv_converter_blue() {
            Rgb rgb = new(100, 255, 145);
            var hsv = ConvertColor.ToHsv(rgb);
            Assert.Equal("hsv(137, 61%, 100%)", hsv.Color);
        }

    }
}
