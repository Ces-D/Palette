using Palette.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Color
    {
        public string Role { get; set; }
        public bool Locked { get; set; }
        public readonly Rgb Rgb;
        public readonly Hex Hex;
        public readonly Hsv Hsv;

        public Color(Rgb rgb)
        {
            Rgb = rgb;
            Hsv = Rgb.ToHsv(rgb);
            Hex = Rgb.ToHex(rgb);
        }

        public Color(Hsv hsv)
        {
            Rgb = Hsv.ToRgb(hsv);
            Hsv = hsv;
            Hex = Hsv.ToHex(hsv);
        }

        public Color(Hex hex)
        {
            Rgb = Hex.ToRgb(hex);
            Hsv = Hex.ToHsv(hex);
            Hex = hex;
        }
    }
}
