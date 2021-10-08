using Palette.Core.Infrastructure.Exceptions;
using Palette.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Hex : IColor<string>
    {
        public string Color { get; init; }
        public string A { get; init; }
        public string B { get; init; }
        public string C { get; init; }

        public Hex(string color)
        {
            if (FormatValidator(color))
            {
                Color = color;
                A = color.Substring(1, 2);
                B = color.Substring(3, 2);
                C = color.Substring(5, 2);
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

        //TODO: public static Hsv ToHsv(Hex hex) { }

        public static Rgb ToRgb(Hex hex)
        {
            byte r = Convert.ToByte(hex.A, 16);
            byte g = Convert.ToByte(hex.B, 16);
            byte b = Convert.ToByte(hex.C, 16);
            return new Rgb(r, g, b);
        }
    }
}
