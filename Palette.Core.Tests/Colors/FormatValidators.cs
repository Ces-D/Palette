﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Palette.Core.Infrastructure.Models.Colors;

namespace Palette.Core.Tests.Colors
{
    public class FormatValidators
    {
        [Theory]
        [InlineData("#452485")]
        [InlineData("#e0e0e0")]
        [InlineData("#f93d5b")]
        [InlineData("#fdfdfd")]
        [InlineData("#fa91f6")]
        [InlineData("#000000")]
        [InlineData("#ffffff")]
        [InlineData("#423f73")]
        public void Check_hex_format_validator_accepted_values(string hex)
        {
            Assert.True(Hex.FormatValidator(hex));
        }

        [Theory]
        [InlineData("rgb(121, 199, 89)")]
        [InlineData("rgb(255, 255, 255)")]
        [InlineData("rgb(0, 0, 0)")]
        [InlineData("rgb(15, 37, 6)")]
        [InlineData("rgb(53, 17, 103)")]
        [InlineData("rgb(10, 0, 0)")]
        [InlineData("rgb(94, 89, 120)")]
        public void Check_rgb_format_validator_accepted_values(string rgb)
        {
            Assert.True(Rgb.FormatValidator(rgb));
        }

        [Theory]
        [InlineData("hsv(317, 43%, 75%)")]
        [InlineData("hsv(0, 0%, 100%)")]
        [InlineData("hsv(0, 0%, 0%)")]
        [InlineData("hsv(153, 55%, 36%)")]
        [InlineData("hsv(344, 72%, 72%)")]
        [InlineData("hsv(356, 95%, 99%)")]
        public void Check_hsv_format_validator_accepted_values(string hsv)
        {
            Assert.True(Hsv.FormatValidator(hsv));
        }
    }
}
