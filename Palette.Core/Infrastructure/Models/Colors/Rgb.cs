using Palette.Core.Infrastructure.Exceptions;
using Palette.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Palette.Core.Infrastructure.Models.Colors
{
    public class Rgb : IColor<byte>
    {
        public string Role { get; init; }
        public bool Locked { get; init; }
        public string Color { get; init; }
        public byte A { get; init; }
        public byte B { get; init; }
        public byte C { get; init; }

        public Rgb(byte a, byte b, byte c)
        {
            Role = "Unkown";
            Locked = false;
            string rgb = $"rgb({a}, {b}, {c})";
            if (FormatValidator(rgb))
            {
                A = a;
                B = b;
                C = c;
                Color = rgb;
            }
            else throw new ColorFormatException("Rgb", rgb);
        }

        public static bool FormatValidator(string color)
        {
            Regex template = new(@"rgb\((\d{1,3}), (\d{1,3}), (\d{1,3})\)");
            Match match = template.Match(color);
            if (match.Success)
            {
                Regex digits = new(@"(\d{1,3})");
                MatchCollection values = digits.Matches(color);
                foreach (Match v in values)
                {
                    if (byte.TryParse(v.Value, out byte result)) { continue; } else return false;
                }
                return true;
            }
            else return false;
        }
    }
}
