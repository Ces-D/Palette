using Palette.Core.Models;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Palette.Domain.Interfaces;

namespace Palette.Core.Infrastructure.Conversions
{
    public static class RgbHexConverter
    {
        public static Hex RgbToHex(Rgb rgb)
        {
            string[] convertedString = BitConverter.ToString(rgb.ToList()).Split("-");
            string hex = String.Join("", convertedString);
            return new Hex(hex);
        }

        public static Rgb HexToRgb(Hex hex)
        {
            byte r = byte.Parse(hex.R, NumberStyles.AllowHexSpecifier);
            byte g = byte.Parse(hex.G, NumberStyles.AllowHexSpecifier);
            byte b = byte.Parse(hex.B, NumberStyles.AllowHexSpecifier);
            return new Rgb(r, g, b);
        }
    }
}
