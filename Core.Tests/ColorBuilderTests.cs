using System;
using Core.Application.Logic;
using Xunit;

namespace Core.Tests
{
    public class ColorBuilderTests
    {
        [Fact]
        public void Builder_creates_white_from_rgb_string()
        {
            var white = ColorBuilder.BuildFromRgb("rgb(255, 255, 255)");
            Assert.Equal("rgb(255, 255, 255)", white.Rgb.ToString());
            Assert.Equal("#FFFFFF", white.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 100%)", white.Hsv.ToString());
        }

        [Fact]
        public void Builder_creates_white_from_hex_string()
        {
            var white = ColorBuilder.BuildFromHex("#ffffff");
            Assert.Equal("rgb(255, 255, 255)", white.Rgb.ToString());
            Assert.Equal("#FFFFFF", white.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 100%)", white.Hsv.ToString());
        }

        [Fact]
        public void Builder_creates_white_from_hsv_string()
        {
            var white = ColorBuilder.BuildFromHsv("hsv(0, 0%, 100%)");
            Assert.Equal("rgb(255, 255, 255)", white.Rgb.ToString());
            Assert.Equal("#FFFFFF", white.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 100%)", white.Hsv.ToString());
        }

        [Fact]
        public void Builder_creates_black_from_rgb_string()
        {
            var black = ColorBuilder.BuildFromRgb("rgb(0, 0, 0)");
            Assert.Equal("rgb(0, 0, 0)", black.Rgb.ToString());
            Assert.Equal("#000000", black.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 0%)", black.Hsv.ToString());
        }

        [Fact]
        public void Builder_creates_black_from_hex_string()
        {
            var black = ColorBuilder.BuildFromHex("#000000");
            Assert.Equal("rgb(0, 0, 0)", black.Rgb.ToString());
            Assert.Equal("#000000", black.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 0%)", black.Hsv.ToString());
        }

        [Fact]
        public void Builder_creates_black_from_hsv_string()
        {
            var black = ColorBuilder.BuildFromHsv("hsv(0, 0%, 0%)");
            Assert.Equal("rgb(0, 0, 0)", black.Rgb.ToString());
            Assert.Equal("#000000", black.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 0%)", black.Hsv.ToString());
        }
    }
}

// TODO: Write tests for a variety of colors for both color builder and complimentary colors