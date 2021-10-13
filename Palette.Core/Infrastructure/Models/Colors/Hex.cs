using Palette.Core.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Hex : IColorFormat<string>
    {
        public string Color { get; init; }
        public string A { get; init; }
        public string B { get; init; }
        public string C { get; init; }

        public Hex(string color)
        {
            if (FormatValidator(color))
            {
                if (color.Length == 4)
                {
                    A = color.Substring(1, 1);
                    B = color.Substring(2, 1);
                    C = color.Substring(3, 1);
                    Color = color;
                }
                else
                {
                    A = color.Substring(1, 2);
                    B = color.Substring(3, 2);
                    C = color.Substring(5, 2);
                    Color = color;
                }
            }
            else throw new ColorFormatException("Hex", color);
        }

        public static bool FormatValidator(string hex)
        {
            Regex template = new(@"^#([a-fA-F0-9]{6}|[a-fA-F0-9]{3})");
            Match match = template.Match(hex);
            if (match.Success)
            {
                return true;
            }

            return false;
        }

        public static Rgb ToRgb(Hex hex)
        {
            byte r = Convert.ToByte(hex.A, 16);
            byte g = Convert.ToByte(hex.B, 16);
            byte b = Convert.ToByte(hex.C, 16);
            return new Rgb(r, g, b);
        }
        public static Hsv ToHsv(Hex hex)
        {
            Rgb rgb = Hex.ToRgb(hex);
            return Rgb.ToHsv(rgb);
        }
    }
}
