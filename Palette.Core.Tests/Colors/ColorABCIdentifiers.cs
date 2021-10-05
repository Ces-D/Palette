using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Palette.Core.Infrastructure.Models.Colors;

namespace Palette.Core.Tests.Colors
{
    public class ColorABCIdentifiers
    {

        [Fact]
        public void Check_hex_abc_values()
        {
            Hex h1 = new("#452485");
            Assert.Equal("24", h1.B);
            Assert.Equal("45", h1.A);
            Assert.Equal("85", h1.C);
        }

        [Fact]
        public void Check_rgb_abc_values()
        {
            Rgb r1 = new(121, 199, 89);
            Assert.Equal(121, r1.A);
            Assert.Equal(199, r1.B);
            Assert.Equal(89, r1.C);
        }

        [Fact]
        public void Check_hsv_abc_values()
        {
            Hsv hsv = new(92, 84, 100);
            Assert.Equal((uint)92, hsv.A);
            Assert.Equal((uint)84, hsv.B);
            Assert.Equal((uint)100, hsv.C);
        }
        
        [Fact]
        public void Check_hsv_abc_values_red()
        {
            Hsv hsv = new(0, 81, 97);
            Assert.Equal((uint)0, hsv.A);
            Assert.Equal((uint)81, hsv.B);
            Assert.Equal((uint)97, hsv.C);
        }
    }
}
