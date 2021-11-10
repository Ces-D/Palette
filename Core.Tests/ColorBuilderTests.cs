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
            Assert.Equal("hsl(0, 0%, 100%)", white.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_white_from_hex_string()
        {
            var white = ColorBuilder.BuildFromHex("#ffffff");
            Assert.Equal("rgb(255, 255, 255)", white.Rgb.ToString());
            Assert.Equal("#FFFFFF", white.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 100%)", white.Hsv.ToString());
            Assert.Equal("hsl(0, 0%, 100%)", white.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_white_from_hsv_string()
        {
            var white = ColorBuilder.BuildFromHsv("hsv(0, 0%, 100%)");
            Assert.Equal("rgb(255, 255, 255)", white.Rgb.ToString());
            Assert.Equal("#FFFFFF", white.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 100%)", white.Hsv.ToString());
            Assert.Equal("hsl(0, 0%, 100%)", white.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_white_from_hsl_string()
        {
            var white = ColorBuilder.BuildFromHsl("hsl(0, 0%, 100%)");
            Assert.Equal("rgb(255, 255, 255)", white.Rgb.ToString());
            Assert.Equal("#FFFFFF", white.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 100%)", white.Hsv.ToString());
            Assert.Equal("hsl(0, 0%, 100%)", white.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_black_from_rgb_string()
        {
            var black = ColorBuilder.BuildFromRgb("rgb(0, 0, 0)");
            Assert.Equal("rgb(0, 0, 0)", black.Rgb.ToString());
            Assert.Equal("#000000", black.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 0%)", black.Hsv.ToString());
            Assert.Equal("hsl(0, 0%, 0%)", black.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_black_from_hex_string()
        {
            var black = ColorBuilder.BuildFromHex("#000000");
            Assert.Equal("rgb(0, 0, 0)", black.Rgb.ToString());
            Assert.Equal("#000000", black.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 0%)", black.Hsv.ToString());
            Assert.Equal("hsl(0, 0%, 0%)", black.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_black_from_hsv_string()
        {
            var black = ColorBuilder.BuildFromHsv("hsv(0, 0%, 0%)");
            Assert.Equal("rgb(0, 0, 0)", black.Rgb.ToString());
            Assert.Equal("#000000", black.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 0%)", black.Hsv.ToString());
            Assert.Equal("hsl(0, 0%, 0%)", black.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_black_from_hsl_string()
        {
            var black = ColorBuilder.BuildFromHsl("hsl(0, 0%, 0%)");
            Assert.Equal("rgb(0, 0, 0)", black.Rgb.ToString());
            Assert.Equal("#000000", black.Hex.ToString());
            Assert.Equal("hsv(0, 0%, 0%)", black.Hsv.ToString());
            Assert.Equal("hsl(0, 0%, 0%)", black.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_red_from_rgb_string()
        {
            var red = ColorBuilder.BuildFromRgb("rgb(112, 38, 54)");
            Assert.Equal("rgb(112, 38, 54)", red.Rgb.ToString());
            Assert.Equal("#702636", red.Hex.ToString());
            Assert.Equal("hsv(348, 66%, 44%)", red.Hsv.ToString());
            Assert.Equal("hsl(348, 49%, 29%)", red.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_red_from_hex_string()
        {
            var red = ColorBuilder.BuildFromHex("#702636");
            Assert.Equal("rgb(112, 38, 54)", red.Rgb.ToString());
            Assert.Equal("#702636", red.Hex.ToString());
            Assert.Equal("hsv(348, 66%, 44%)", red.Hsv.ToString());
            Assert.Equal("hsl(348, 49%, 29%)", red.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_red_from_hsv_string()
        {
            var red = ColorBuilder.BuildFromHsv("hsv(347, 66%, 44%)");
            Assert.Equal("rgb(112, 38, 54)", red.Rgb.ToString());
            Assert.Equal("#702636", red.Hex.ToString());
            Assert.Equal("hsv(347, 66%, 44%)", red.Hsv.ToString());
            Assert.Equal("hsl(348, 49%, 29%)", red.Hsl.ToString());
        }
        // TODO: The HSl to RGB function return very different values compared to other functions
        // especially for the test below

        [Fact]
        public void Builder_creates_red_from_hsl_string()
        {
            var red = ColorBuilder.BuildFromHsl("hsl(347, 66%, 29%)");
            Assert.Equal("rgb(123, 25, 46)", red.Rgb.ToString());
            Assert.Equal("#7B192E", red.Hex.ToString());
            Assert.Equal("hsv(348, 80%, 48%)", red.Hsv.ToString());
            Assert.Equal("hsl(347, 66%, 29%)", red.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_green_from_rgb_string()
        {
            var green = ColorBuilder.BuildFromRgb("rgb(192, 225, 21)");
            Assert.Equal("rgb(192, 225, 21)", green.Rgb.ToString());
            Assert.Equal("#C0E115", green.Hex.ToString());
            Assert.Equal("hsv(69, 91%, 88%)", green.Hsv.ToString());
            Assert.Equal("hsl(69, 83%, 48%)", green.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_green_from_hex_string()
        {
            var green = ColorBuilder.BuildFromHex("#C0E115");
            Assert.Equal("rgb(192, 225, 21)", green.Rgb.ToString());
            Assert.Equal("#C0E115", green.Hex.ToString());
            Assert.Equal("hsv(69, 91%, 88%)", green.Hsv.ToString());
            Assert.Equal("hsl(69, 83%, 48%)", green.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_green_from_hsv_string()
        {
            var green = ColorBuilder.BuildFromHsv("hsv(69, 91%, 88%)");
            Assert.Equal("rgb(194, 224, 20)", green.Rgb.ToString());
            Assert.Equal("#C2E014", green.Hex.ToString());
            Assert.Equal("hsv(69, 91%, 88%)", green.Hsv.ToString());
            Assert.Equal("hsl(68, 84%, 48%)", green.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_green_from_hsl_string()
        {
            var green = ColorBuilder.BuildFromHsl("hsl(70, 83%, 48%)");
            Assert.Equal("rgb(190, 224, 21)", green.Rgb.ToString());
            Assert.Equal("#BEE015", green.Hex.ToString());
            Assert.Equal("hsv(69, 91%, 88%)", green.Hsv.ToString());
            Assert.Equal("hsl(70, 83%, 48%)", green.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_blue_from_rgb_string()
        {
            var blue = ColorBuilder.BuildFromRgb("rgb(15, 35, 113)");
            Assert.Equal("rgb(15, 35, 113)", blue.Rgb.ToString());
            Assert.Equal("#0F2371", blue.Hex.ToString());
            Assert.Equal("hsv(229, 87%, 44%)", blue.Hsv.ToString());
            Assert.Equal("hsl(229, 77%, 25%)", blue.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_blue_from_hex_string()
        {
            var blue = ColorBuilder.BuildFromHex("#0F2371");
            Assert.Equal("rgb(15, 35, 113)", blue.Rgb.ToString());
            Assert.Equal("#0F2371", blue.Hex.ToString());
            Assert.Equal("hsv(229, 87%, 44%)", blue.Hsv.ToString());
            Assert.Equal("hsl(229, 77%, 25%)", blue.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_blue_from_hsv_string()
        {
            var blue = ColorBuilder.BuildFromHsv("hsv(229, 87%, 44%)");
            Assert.Equal("rgb(15, 32, 112)", blue.Rgb.ToString());
            Assert.Equal("#0F2070", blue.Hex.ToString());
            Assert.Equal("hsv(229, 87%, 44%)", blue.Hsv.ToString());
            Assert.Equal("hsl(231, 76%, 25%)", blue.Hsl.ToString());
        }

        [Fact]
        public void Builder_creates_blue_from_hsl_string()
        {
            var blue = ColorBuilder.BuildFromHsl("hsl(228, 77%, 25%)");
            Assert.Equal("rgb(15, 34, 113)", blue.Rgb.ToString());
            Assert.Equal("#0F2271", blue.Hex.ToString());
            Assert.Equal("hsv(229, 87%, 44%)", blue.Hsv.ToString());
            Assert.Equal("hsl(228, 77%, 25%)", blue.Hsl.ToString());
        }
    }
}

